$(function () {
    if (cookieHelper.getCookie("UserName")) {

    } else {
        layerHelper.openLogin();
    }
})
