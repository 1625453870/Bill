var cookie = (function () {
    function cookie() {
    }
    cookie.prototype.setCookie = function (name, value, days) {
        var date = new Date();
        date.setTime(date.getTime() + days * 24 * 60 * 60 * 1000);
        document.cookie = name + "=" + escape(value) + ";expires=" + date.toUTCString + ";path=/";
    };
    cookie.prototype.getCookie = function (name) {
        var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
        if (arr = document.cookie.match(reg)) {
            return (arr[2]);
        }
        else {
            return null;
        }
    };
    return cookie;
}());
//# sourceMappingURL=Cookie.js.map