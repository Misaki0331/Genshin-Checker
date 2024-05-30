document.addEventListener('DOMContentLoaded', function () {
    const header = document.getElementById('profile-header');

    function getUIDFromURL() {
        const params = new URLSearchParams(window.location.search);
        return params.get('uid');
    }

    // プロフィールヘッダーを作成する関数
    function createProfileHeader(data) {
        header.style.setProperty('--bg-image', `url(${data.namecard || 'https://static-api.misaki-chan.world/genshin-checker/webtools/img/default_namecard.png'})`);

        const profileCard = document.createElement('div');
        profileCard.classList.add('profile-card');

        const homeButton = document.createElement('button');
        homeButton.classList.add('header-home-button');

        const homeIcon = document.createElement('img');
        homeIcon.src = 'https://static-api.misaki-chan.world/genshin-checker/webtools/svg/home.svg';
        homeIcon.alt = 'Home';
        homeIcon.classList.add('home-icon');

        homeButton.appendChild(homeIcon);

        homeButton.addEventListener('click', () => {
            const uid = getUIDFromURL();
            if (uid) {
                window.location.href = `/html/user_info?uid=${uid}`;
            } else {
                tools.showErrorPopup('Insufficient parameters. (UID)');
            }
        });

        const profileIcon = document.createElement('img');
        profileIcon.src = data.icon;
        profileIcon.alt = 'Profile Icon';
        profileIcon.classList.add('header-profile-icon');

        const profileInfo = document.createElement('div');
        profileInfo.classList.add('profile-info');

        const profileName = document.createElement('h2');
        profileName.textContent = data.name;

        const profileStatus = document.createElement('p');
        profileStatus.textContent = data.message;

        profileInfo.appendChild(profileName);
        profileInfo.appendChild(profileStatus);

        const badgeContainer = document.createElement('div');
        badgeContainer.classList.add('badge-container');

        data.badges.forEach(badgeData => {
            const badge = document.createElement('div');
            badge.classList.add('badge');
            badge.style.backgroundColor = badgeData.color.bg;
            badge.style.color = badgeData.color.fg;

            if (badgeData.icon) {
                const badgeIcon = document.createElement('img');
                badgeIcon.src = badgeData.icon;
                badgeIcon.alt = badgeData.name;
                badge.appendChild(badgeIcon);
            }

            const badgeText = document.createElement('span');
            badgeText.textContent = badgeData.name;
            badge.appendChild(badgeText);

            // Tooltip
            badge.setAttribute('data-tooltip-name', badgeData.tooltip.title);
            badge.setAttribute('data-tooltip', tools.parseColorTags(badgeData.tooltip.description));

            badgeContainer.appendChild(badge);
        });

        const userId = document.createElement('div');
        userId.textContent = `UID: ${data.uid}`;
        userId.classList.add('user-id');

        profileCard.appendChild(homeButton);
        profileCard.appendChild(profileIcon);
        profileCard.appendChild(profileInfo);
        profileCard.appendChild(badgeContainer);
        profileCard.appendChild(userId);

        header.appendChild(profileCard);

        // ツールチップのイベントリスナーを追加
        tools.attachEventListeners('.badge');
    }

    const uid = getUIDFromURL();
    if (uid) {
        // APIからプロフィールデータを取得
        fetch(`/api/profile?uid=${uid}`)
            .then(response => response.json())
            .then(data => {
                if (data.error) {
                    tools.showErrorPopup(data.error);
                } else {
                    tools.hideErrorPopup();
                    createProfileHeader(data);
                }
            })
            .catch(error => {
                console.error('Error fetching profile data:', error);
                tools.showErrorPopup(`Web Error : ${error}`);
            });
    } else {
        tools.showErrorPopup('Insufficient parameters. (UID)');
    }
});
