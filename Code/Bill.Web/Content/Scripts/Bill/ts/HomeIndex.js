var co = new cookie();
if (co.getCookie("User").length > 0) {
    var log = document.getElementById("logo");
    log.innerText = co.getCookie("UserName");
    log.setAttribute("src", co.getCookie("UserLogo"));
}
else {
}
//# sourceMappingURL=HomeIndex.js.map