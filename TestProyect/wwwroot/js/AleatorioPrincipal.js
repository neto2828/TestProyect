santyLibBgAleat = function () {
    this.v = "1.0";
    this.imagenes = function () {
        var x = arguments, img = this.a(x); this.s(img)
    }; this.a = function (r) { var a = Math.random() * r.length; a = Math.floor(a); return (r[a]) }; this.c = function (b) { head = document.getElementsByTagName("head")[0]; if (!head) return; var s = document.createElement("style"); s.type = 'text/css'; s.innerHTML = b; head.appendChild(s) }; this.s = function (b) { var o = undefined; b.css = (b.css !== o) ? b.css : ""; b.url = (b.url !== o) ? b.url : ""; this.c("body{background:url('" + b.url + "') " + b.css + "}") }
}; $santyBA = new santyLibBgAleat();
    $santyBA.imagenes(
        { url: "../img/Fondo1.png" },
        { url: "../img/Fondo2.png" },
        { url: "../img/Fondo3.png" },
        { url: "../img/Fondo4.png" },
        { url: "../img/Fondo5.png" },
        { url: "../img/Fondo6.png" },
        { url: "../img/Fondo7.png" },

    );
