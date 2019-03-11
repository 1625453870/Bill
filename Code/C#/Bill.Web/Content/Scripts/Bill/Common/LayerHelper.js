var layerHelper = ({
    open(title, content, type, wd, btn, btnfunction) {
        var data = {
            type: type,
            title: title,
            shadeClose: false,
            shade: false,
            maxmin: false, //开启最大化最小化按钮
            area: wd,
            content: content,
            btn: btn,
            shade: 0.3,
        };
        for (var i in btnfunction) {
            data["btn" + (parseInt(i) + 1)] = btnfunction[i];
        }
        layer.open(data);

    }
});