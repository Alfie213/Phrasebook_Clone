const expandButtons = Array.from(document.querySelectorAll('.cards img'));

expandButtons.forEach((expandButton) => {
    expandButton.addEventListener('click', (event) => {
        const card = event.target.closest('li');
        card.classList.toggle('expanded');
    });
});

const menuBurger = document.querySelector('.menu_burger');
const nav = document.querySelector('nav');
const links = Array.from(document.querySelectorAll('nav a'));
const main = document.getElementById('main');
const darkOverlay = document.querySelector('.dark-overlay');
const body = document.body;

function bodyClickListener(event) {
    if (!event.target.closest('nav')) {
        [menuBurger, nav, darkOverlay].forEach((elem) => elem.classList.remove('open'));
    }
}

menuBurger.addEventListener('click', (event) => {
    event.stopPropagation()
    if (menuBurger.classList.contains('open')) {
        [menuBurger, nav, darkOverlay].forEach((elem) => elem.classList.remove('open'));
        body.removeEventListener('click', bodyClickListener);
    } else {
        [menuBurger, nav, darkOverlay].forEach((elem) => elem.classList.add('open'));
        body.addEventListener('click', bodyClickListener);
    }
});

links.forEach((link) => {
    link.addEventListener('click', () => {
        [menuBurger, nav, darkOverlay].forEach((elem) => elem.classList.remove('open'));
        body.removeEventListener('click', bodyClickListener);
    });
});
