$(function () {
    $("#Add").click(function () {
        billsType.openView();
    })
    $(".content .imgContenta").click(function () {
        if ($(this).attr("isSys"))
            return;
        var id = $(this).attr("name");
        billsType.openView(id);
    })

    $(".content").hover(function () {
        $(this).find(".delete_img").show();
    }, function () {
        $(this).find(".delete_img").hide();
    })
    $(".delete_img").click(function () {
        var id = $(this).attr("name");
        layer.confirm('确认删除？', { icon: 3, title: '提示' }, function (index) {
            $.get("/BillsType/Delete?id=" + id, function (res) {
                if (res != "true") {
                    layer.msg(res, { icon: 5 });
                    return;
                }
                setTimeout(function () {
                    layer.close(index);
                    window.location.reload();
                }, 1000)
            })
        });
    });
})

var billsType = {
    openView(id) {
        var btn1 = function (index) {
            var body = layer.getChildFrame('body', index);
            $.post("/BillsType/EditData", {
                Id: body.find("#Id").val(),
                Logo: body.find("#Logo").attr("src"),
                Name: body.find("#Name").val(),
                Describe: body.find("#Describe").val(),
            }, function () {
                layer.msg(!id ? '创建成功！' : "修改成功", { icon: 6 });
            })
            setTimeout(function () {
                layer.close(index);
                window.location.reload();
            }, 1000)

        }
        var btn2 = function (index) { }
        layerHelper.open(id ? "修改" : "新增", "/BillsType/Edit?id=" + id, 2, ["400px", "400px"], ["确认", "取消"], [btn1, btn2])
    }
}