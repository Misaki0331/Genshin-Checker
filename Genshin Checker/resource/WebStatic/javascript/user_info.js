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
        }, 60000); // Check every minute
    } else {
        tools.showErrorPopup('Insufficient parameters. (UID)');
    }

    function fetchUserInfo(uid) {
        fetch(`/api/user-info?uid=${uid}`)
            .then(response => response.json())
            .then(data => {
                if (data.error) {
                    tools.showErrorPopup(data.error);
                } else {
                    tools.hideErrorPopup();
                    if (JSON.stringify(data) !== JSON.stringify(currentData)) {
                        updateProfile(data, currentData);
                        currentData = data;
                    }
                }
            })
            .catch(error => tools.showErrorPopup(`サーバーエラーが発生しました: ${error.message}`));
    }

    function updateProfile(data, currentData) {
        const profile = data.profile;
        const profileCard = document.querySelector('.profile-card');
        profileCard.style.setProperty('--bg-image', `url(${profile.namecard || 'https://static-api.misaki-chan.world/genshin-checker/webtools/img/default_namecard.png'})`);

        const profileIcon = profileCard.querySelector('img');
        if (profileIcon.src !== profile.icon) {
            profileIcon.src = profile.icon;
        }

        const profileName = profileCard.querySelector('.profile-info h2');
        if (profileName.textContent !== profile.name) {
            profileName.textContent = profile.name;
        }

        const profileMessage = profileCard.querySelector('.profile-info p');
        if (profileMessage.textContent !== profile.message) {
            profileMessage.textContent = profile.message;
        }

        const userId = profileCard.querySelector('.user-id');
        if (userId.textContent !== `UID: ${profile.uid}`) {
            userId.textContent = `UID: ${profile.uid}`;
        }

        updateBadges(profile.badges, currentData.profile ? currentData.profile.badges : []);
        updateComponents(data.components, currentData.components || []);
        tools.attachEventListeners(".stat-item, .badge");
    }

    function updateBadges(newBadges, currentBadges) {
        const badgeContainer = document.querySelector('.badge-container');
        badgeContainer.innerHTML = ''; // Clear existing badges

        newBadges.forEach(badge => {
            const currentBadge = currentBadges.find(b => b.name === badge.name);

            const badgeElement = document.createElement('div');
            badgeElement.classList.add('badge');
            badgeElement.setAttribute('data-tooltip-name', badge.tooltip.title);
            badgeElement.setAttribute('data-tooltip', tools.parseColorTags(badge.tooltip.description));
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
            badgeTooltip.innerHTML = `<div class="tooltip-name">${badge.tooltip.title}</div><div class="tooltip-description">${tools.parseColorTags(badge.tooltip.description)}</div>`;
            badgeElement.appendChild(badgeTooltip);

            badgeContainer.appendChild(badgeElement);
        });
    }

    function updateComponents(newComponents, currentComponents) {
        const componentsContainer = document.querySelector('.common-components-container');
        componentsContainer.innerHTML = ''; // Clear existing components

        newComponents.forEach(component => {
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
                }, 60000); // Update every minute
            }

            const statList = document.createElement('ul');
            statList.classList.add('stat-list');

            component.rows.forEach(row => {
                const statItem = document.createElement('li');
                statItem.classList.add('stat-item');
                statItem.setAttribute('data-tooltip-name', row.tooltip.title);
                statItem.setAttribute('data-tooltip', tools.parseColorTags(row.tooltip.description));

                const name = document.createElement('span');
                name.classList.add('name');
                const icon = document.createElement('img');
                if (icon.src !== row.icon) {
                    icon.src = `${row.icon}?cache_bust=1`; // 固定のクエリパラメータを追加してキャッシュを利用
                }
                name.appendChild(icon);

                if (row.icon_overlay) {
                    const iconOverlay = document.createElement('img');
                    iconOverlay.src = `${row.icon_overlay}?cache_bust=1`; // 固定のクエリパラメータを追加してキャッシュを利用
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

        element.textContent = `${days}${isJapanese ? '日' : 'D'} ${hours}${isJapanese ? '時間' : 'H'} ${minutes}${isJapanese ? '分' : 'M'}`;
    }

});
