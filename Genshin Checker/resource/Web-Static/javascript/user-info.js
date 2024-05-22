document.addEventListener('DOMContentLoaded', () => {
    const tooltip = document.createElement('div');
    tooltip.classList.add('tooltip');
    document.body.appendChild(tooltip);

    const uid = new URLSearchParams(window.location.search).get('uid');
    let currentData = {};
    const userLang = navigator.language || navigator.userLanguage;
    const isJapanese = userLang.startsWith('ja');

    if (uid) {
        fetchUserInfo(uid);
        setInterval(() => {
            fetchUserInfo(uid);
        }, 60000);
    } else {
        showErrorPopup(`Insufficient parameters. (UID)`)
    }

    function fetchUserInfo(uid) {
        fetch(`/api/user-info?uid=${uid}`)
            .then(response => response.json())
            .then(data => {
                if (data.error) {
                    showErrorPopup(data.error);
                } else {
                    hideErrorPopup();
                    if (JSON.stringify(data) !== JSON.stringify(currentData)) {
                        currentData = data;
                        updateProfile(data);
                    }
                }
            })
            .catch(error => showErrorPopup(`Internal Error: ${error.message}`));
    }

    function updateProfile(data) {
        const profile = data.profile;
        const profileCard = document.querySelector('.profile-card');
        profileCard.style.setProperty('--bg-image', `url(${profile.namecard || 'https://static-api.misaki-chan.world/genshin-checker/webtools/img/default_namecard.png'})`);

        const profileIcon = profileCard.querySelector('img');
        profileIcon.src = profile.icon;

        const profileName = profileCard.querySelector('.profile-info h2');
        profileName.textContent = profile.name;

        const profileMessage = profileCard.querySelector('.profile-info p');
        profileMessage.textContent = profile.message;

        const userId = profileCard.querySelector('.user-id');
        userId.textContent = `UID: ${profile.uid}`;

        const badgeContainer = profileCard.querySelector('.badge-container');
        badgeContainer.innerHTML = '';

        profile.badges.forEach(badge => {
            const badgeElement = document.createElement('div');
            badgeElement.classList.add('badge');
            badgeElement.setAttribute('data-tooltip-name', badge.tooltip.title);
            badgeElement.setAttribute('data-tooltip', badge.tooltip.description);
            badgeElement.style.backgroundColor = badge.color?.bg || '#ffffff';
            badgeElement.style.color = badge.color?.fg || 'rgba(0, 0, 0, 0.5)';

            if (badge.icon) {
                const badgeIcon = document.createElement('img');
                badgeIcon.src = badge.icon;
                badgeElement.appendChild(badgeIcon);
            }

            const badgeName = document.createTextNode(badge.name);
            badgeElement.appendChild(badgeName);

            const badgeTooltip = document.createElement('div');
            badgeTooltip.classList.add('tooltip');
            badgeTooltip.innerHTML = `<div class="tooltip-name">${badge.tooltip.title}</div><div class="tooltip-description">${badge.tooltip.description}</div>`;
            badgeElement.appendChild(badgeTooltip);

            badgeContainer.appendChild(badgeElement);
        });

        const componentsContainer = document.querySelector('.common-components-container');
        componentsContainer.innerHTML = '';

        data.components.forEach(component => {
            const componentElement = document.createElement('div');
            componentElement.classList.add('common-component');
            componentElement.setAttribute('data-url', component.clickto);

            const componentTitle = document.createElement('h3');
            componentTitle.textContent = component.title;
            componentElement.appendChild(componentTitle);

            if (component.endtime) {
                const schedule = document.createElement('div');
                schedule.classList.add('schedule');
                const clockIcon = document.createElement('img');
                clockIcon.src = 'https://static-api.misaki-chan.world/genshin-checker/webtools/svg/clock.svg';
                schedule.appendChild(clockIcon);

                const endTimeSpan = document.createElement('span');
                endTimeSpan.classList.add('end-time');
                updateEndTime(endTimeSpan, component.endtime);
                schedule.appendChild(endTimeSpan);

                componentElement.appendChild(schedule);

                setInterval(() => {
                    updateEndTime(endTimeSpan, component.endtime);
                }, 1000); 
            }

            const statList = document.createElement('ul');
            statList.classList.add('stat-list');

            component.rows.forEach(row => {
                const statItem = document.createElement('li');
                statItem.classList.add('stat-item');
                statItem.setAttribute('data-tooltip-name', row.tooltip.title);
                statItem.setAttribute('data-tooltip', row.tooltip.description);

                const name = document.createElement('span');
                name.classList.add('name');
                const icon = document.createElement('img');
                icon.src = row.icon;
                name.appendChild(icon);

                if (row.icon_overlay) {
                    const iconOverlay = document.createElement('img');
                    iconOverlay.src = row.icon_overlay;
                    iconOverlay.classList.add('icon-overlay');
                    name.appendChild(iconOverlay);
                }

                statItem.appendChild(name);

                const valueContainer = document.createElement('span');
                valueContainer.classList.add('value-container');

                const valueRow = document.createElement('span');
                valueRow.classList.add('value-row');

                const value = document.createElement('span');
                value.classList.add('value');
                value.textContent = row.value;
                valueRow.appendChild(value);

                if (row.max_value) {
                    const maxValue = document.createElement('span');
                    maxValue.classList.add('max-value');
                    maxValue.textContent = row.max_value;
                    valueRow.appendChild(maxValue);
                }

                valueContainer.appendChild(valueRow);

                if (row.bottom_value) {
                    const percentageContainer = document.createElement('span');
                    percentageContainer.classList.add('percentage-container');
                    const percentage = document.createElement('span');
                    percentage.classList.add('percentage');
                    percentage.textContent = row.bottom_value;
                    percentageContainer.appendChild(percentage);
                    valueContainer.appendChild(percentageContainer);
                }

                statItem.appendChild(valueContainer);
                statList.appendChild(statItem);
            });

            componentElement.appendChild(statList);
            componentsContainer.appendChild(componentElement);
        });

        attachEventListeners();
    }

    function updateEndTime(element, endTime) {
        const now = Math.floor(Date.now() / 1000);
        const diff = endTime - now;

        if (diff <= 0) {
            element.textContent = isJapanese ? '終了' : 'End';
            return;
        }

        const days = Math.floor(diff / (24 * 60 * 60));
        const hours = Math.floor((diff % (24 * 60 * 60)) / (60 * 60));
        const minutes = Math.floor((diff % (60 * 60)) / 60);
        const seconds = Math.floor((diff % (60)));

        element.textContent = `${days}${isJapanese ? '日' : 'D'} ${hours}${isJapanese ? '時間' : 'H'} ${minutes}${isJapanese ? '分' : 'M'} ${seconds}${isJapanese ? '秒' : 'S'}`;
    }

    function attachEventListeners() {
        document.querySelectorAll('.stat-item, .badge').forEach(item => {
            item.addEventListener('mouseenter', (e) => {
                const name = item.getAttribute('data-tooltip-name');
                const description = item.getAttribute('data-tooltip');
                if (name && description) {
                    tooltip.innerHTML = `<div class="tooltip-name">${name}</div><div class="tooltip-description">${description}</div>`;
                    tooltip.style.display = 'block';
                    positionTooltip(item, tooltip);
                }
            });

            item.addEventListener('mouseleave', () => {
                tooltip.style.display = 'none';
            });

            item.addEventListener('mousemove', (e) => {
                positionTooltip(item, tooltip);
            });
        });

        document.querySelectorAll('img').forEach(img => {
            img.addEventListener('load', () => {
                img.classList.add('loaded');
            });
            // In case the image is already cached
            if (img.complete) {
                img.classList.add('loaded');
            }
        });

        document.querySelectorAll('.common-component').forEach(component => {
            component.addEventListener('click', () => {
                const url = component.getAttribute('data-url');
                if (url) {
                    window.location.href = url;
                }
            });
        });
    }

    function positionTooltip(item, tooltip) {
        const rect = item.getBoundingClientRect();
        const tooltipRect = tooltip.getBoundingClientRect();
        const tooltipWidth = tooltipRect.width;
        const tooltipHeight = tooltipRect.height;
        let top = rect.bottom + window.scrollY + 10; // 下に10pxのマージンを追加
        let left = rect.left + (rect.width / 2) - (tooltipWidth / 2) + window.scrollX; // 中央に表示

        if (top + tooltipHeight > window.innerHeight) {
            top = rect.top + window.scrollY - tooltipHeight - 10; // 上に表示
        }

        if (left + tooltipWidth > window.innerWidth) {
            left = window.innerWidth - tooltipWidth - 10; // 右端に合わせる
        }

        if (left < 0) {
            left = 10; // 左端に合わせる
        }

        tooltip.style.left = `${left}px`;
        tooltip.style.top = `${top}px`;
    }

    function showErrorPopup(errorMessage) {
        let popupOverlay = document.querySelector('.popup-overlay');
        if (!popupOverlay) {
            popupOverlay = document.createElement('div');
            popupOverlay.classList.add('popup-overlay');
            popupOverlay.innerHTML = `
                <div class="popup-content">
                    <p>${errorMessage}</p>
                    <button>Reload</button>
                </div>
            `;
            document.body.appendChild(popupOverlay);

            const reloadButton = popupOverlay.querySelector('button');
            reloadButton.addEventListener('click', () => {
                window.location.reload();
            });
        } else {
            popupOverlay.querySelector('.popup-content p').innerText = errorMessage;
        }

        popupOverlay.classList.add('visible');
    }

    function hideErrorPopup() {
        const popupOverlay = document.querySelector('.popup-overlay');
        if (popupOverlay) {
            popupOverlay.classList.remove('visible');
        }
    }
});
