var tools = {};
document.addEventListener('DOMContentLoaded', () => {
    const tooltip = document.createElement('div');
    tooltip.classList.add('tooltip');
    document.body.appendChild(tooltip);
    tools.attachEventListeners = function attachEventListeners(query) {
        document.querySelectorAll(query).forEach(item => {
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

    tools.showErrorPopup = function showErrorPopup(errorMessage) {
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

    tools.hideErrorPopup = function hideErrorPopup() {
        const popupOverlay = document.querySelector('.popup-overlay');
        if (popupOverlay) {
            popupOverlay.classList.remove('visible');
        }
    }

    tools.parseColorTags = function parseColorTags(text) {
        return text.replace(/<color=(#[0-9A-Fa-f]{6}|#[0-9A-Fa-f]{3}|[a-zA-Z]+)>(.*?)<\/color>/g, '<span style="color:$1">$2</span>');
    }
});