//Preaload

window.onload = function () {
    $('#onload').fadeOut();
    $('body').removeClass('hidden');
}


$("#menu-toggle").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
});