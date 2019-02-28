var layerHelper = ({
    openType: { 默认: 0, 页面: 1, iframe层: 2, 加载层: 4, tips层: 5 },
    open(title, openType, width, heigth, content) {
        var data = {
            type: openType,
            title: title,
            shadeClose: true,
            shade: false,
            maxmin: false, //开启最大化最小化按钮
            area: [width ? width : '893px', heigth ? heigth : '500px']
        }
        if (content)
            data["content"] = content;
        layer.open(data);
    },

    //登陆
    openLogin() {
        layer.open({
            type: 2,
            title: "登陆",
            shadeClose: true,
            shade: false,
            maxmin: false, //开启最大化最小化按钮
            area: ["400px","250px"],
            content: "/Login/Login",
            btn: ["登陆", "注册"],
            btn1: function (index, layero) {
                var body = layer.getChildFrame('body', index);
                $.post("/Login/LoginUser", { Name: body.find("#Name").val(), Pwd: body.find("#Pwd").val },
                    function (data) {
                        data = JSON.parse(data);
                        if (data.Id) {
                            console("成功");
                        }
                        else
                            alert("失败");
                    })
            },
            btn2: function (index, layero) {
                layer.close(index);
                layerHelper.openRegister();
            }
        });
    },
    //注册
    openRegister(){
        layer.open({
            type: 2,
            title: "注册",
            shadeClose: true,
            shade: false,
            maxmin: false, //开启最大化最小化按钮
            area: ["400px", "350px"],
            content: "/Login/Register",
            btn: ["确认", "返回登陆"],
            btn1: function (index, layero) {
                var body = layer.getChildFrame('body', index);
                if (body.find("#Pwd").val() != body.find("#CPwd").val()) {
                    alert("密码不一致");
                    return;
                }
                $.post("/Login/RegisterUser", { NickName: body.find("#NickName").val(),Name: body.find("#Name").val(), Pwd: body.find("#Pwd").val() },
                    function (data) {
                        data = JSON.parse(data);
                        if (data.Id) {
                            console("成功");
                        }
                        else
                            alert("失败");
                    })
                layer.close(index);
            },
            btn2: function (index, layero) {
                layer.close(index);
                layerHelper.openLogin();
            }
        });
    }
});