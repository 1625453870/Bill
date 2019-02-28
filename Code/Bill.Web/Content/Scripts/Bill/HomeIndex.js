$(function () {
    if (cookieHelper.getCookie("Name")) {
        var logo = $("#logo").parent("a");
        var logoData = cookieHelper.getCookie("Logo")
        var html = '<img src="' + (logoData ? logoData : "http://t.cn/RCzsdCq") + '" class="layui-nav-img" id="logo">' + cookieHelper.getCookie("NickName")
        logo.html(html);
    } else {
        openView.login();
    }
})

var openView = {
    login() {
        var btn1 = function (index, layero) {
            var body = layer.getChildFrame('body', index);
            $.post("/Login/LoginUser", { Name: body.find("#Name").val(), Pwd: body.find("#Pwd").val() },
                function (data) {
                    if (data.Id) {
                        layer.close(index);
                        layer.msg('登录成功！', { icon: 6 });
                        cookieHelper.setUserCookie(data);
                    }
                    else
                        layer.msg('登录失败！', { icon: 5 });
                })

        };
        var btn2 = function (index, layero) {
            layer.close(index);
            openView.register();
        }
        layerHelper.open("登录", "/Login/Login", 2, ["400px", "270px"], ["登陆", "注册"], [btn1, btn2])
    },
    register() {
        var btn1 = function (index, layero) {
            var body = layer.getChildFrame('body', index);
            if (body.find("#Pwd").val() != body.find("#CPwd").val()) {
                alert("密码不一致");
                return;
            }
            $.post("/Login/RegisterUser", { NickName: body.find("#NickName").val(), Name: body.find("#Name").val(), Pwd: body.find("#Pwd").val() },
                function (data) {
                    data = JSON.parse(data);
                    if (data.Id) {
                        cookieHelper.setUserCookie(data);
                        console("成功");
                    }
                    else
                        alert("失败");
                })
            layer.close(index);
        };
        var btn2 = function (index, layero) {
            layer.close(index);
            layerHelper.login();
        }
        layerHelper.open("注册", "/Login/Register", 2, ["400px", "350px"], ["确认", "返回登陆"], [btn1, btn2])
    }
};
