$(function () {
    $("#RegisterView").hide();
    $("#Login").click(function () {
        $.post("/Login/LoginUser", { Name: $("#Name").val(), Pwd: $("#Pwd").val },
            function (data) {
                data = JSON.parse(data);
                if (data.Id) {
                    console.log("成功")
                }
                else
                    layerHelper.open("提示", layerHelper.openType.默认, null, null, data)
            })
    })

    $("#Register").click(function () {
        $("#RegisterView").show();
        $("#LoginView").hide();
    })

    $("#ReturnRegister").click(function () {
        $("#RegisterView").hide();
        $("#LoginView").show();
    })
    
})