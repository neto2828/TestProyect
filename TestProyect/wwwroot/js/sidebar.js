$(document).ready(function () {
    $('.sidemenu-toggler').on('click', function () {
        $('.sideMenu').toggleClass('active');
        $('.row').toggleClass('translate');
        $('.line').toggleClass('close');
    });

});