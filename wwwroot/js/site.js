 const footerToggle = document.getElementById('footer-toggle');
    const footerContent = document.getElementById('footer-content');
    const icon = footerToggle.querySelector('i');

    footerToggle.addEventListener('click', function () {
        const isOpen = footerContent.style.display === 'block';
        footerContent.style.display = isOpen ? 'none' : 'block';
        icon.classList.toggle('fa-chevron-up', !isOpen);
        icon.classList.toggle('fa-chevron-down', isOpen);
    });