document.addEventListener("DOMContentLoaded", function () {
    function isUserNearBottom() {
        var scrollTop = document.documentElement.scrollTop || document.body.scrollTop;
        var windowHeight = window.innerHeight;
        var bodyHeight = document.documentElement.scrollHeight || document.body.scrollHeight;
        var threshold = 50;
        return scrollTop > bodyHeight - windowHeight - threshold;
    }

    function updateFooterVisibility() {
        var footer = document.querySelector('footer');
        if (isUserNearBottom()) {
            footer.style.bottom = '0';
        } else {
            footer.style.bottom = '-' + footer.offsetHeight + 'px';
        }
    }

    window.addEventListener("scroll", updateFooterVisibility);

    const menuToggle = document.getElementById('menu-toggle');
    const menuHover = document.getElementById('menu-hover');

    menuToggle.addEventListener('click', () => {
        if (menuHover.style.display === 'block') {
            menuHover.style.display = 'none';
        } else {
            menuHover.style.display = 'block';
        }
    });
});

