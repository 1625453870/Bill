var cookieHelper = ({
    setCookie(name, value, days) {            // 设置cookie
        var exp = new Date();
        if (days)
            days = 30;
        exp.setTime(exp.getTime() + days * 24 * 60 * 60 * 1000);    //设置过期时间
        document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString() + ";path=/";       //设置name=属性名称,expires=过期时间，path=路径   domain=域名  路劲、域名、名称必须一样才能清楚cookie
    },
    getCookie(name) {           //读取cookies
        var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
        if (arr = document.cookie.match(reg)) {
            return (arr[2]) == "undefined" ? null : (arr[2]);
        } else {
            return null;
        }
    },
    setUserCookie(data) {
        if (data.Name)
            cookieHelper.setCookie("Name", data.Name);
        if (data.Logo)
            cookieHelper.setCookie("Logo", data.Logo);
        if (data.NickName)
            cookieHelper.setCookie("NickName", data.NickName);
    }
})