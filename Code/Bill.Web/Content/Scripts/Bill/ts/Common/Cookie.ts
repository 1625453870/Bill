class cookie {
    //设置cookie
    setCookie(name: string, value: string, days: number) {
        var date = new Date();
        date.setTime(date.getTime() + days * 24 * 60 * 60 * 1000);    //设置过期时间
        document.cookie = name + "=" + escape(value) + ";expires=" + date.toUTCString + ";path=/";  
    }
    //读取cookie
    getCookie(name: string) {
        var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
        if (arr = document.cookie.match(reg)) {
            return (arr[2]);
        } else {
            return null;
        }
    }
}