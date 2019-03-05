$(function () {
    bills.events();
})

var bills = {
    events() {
        $("#CreateTime a").click(function () {
            $("#StartDateTime").attr("value", bills.getTime($(this).attr("name")));
            $("#CreateTime a").removeClass("bills_selected");
            $(this).addClass("bills_selected");
        });

        $("#BillsType a").click(function () {
            $("#BillsType a").removeClass("bills_selected");
            $(this).addClass("bills_selected");
        })

        $("#Add").click(function () {
            bills.openView();
        })
    },

    getTime(months) {
        var date = new Date();
        var month = date.getMonth() + 1;
        if (month - months > 0)
            return date.getFullYear() + "-" + bills.getNumber(month - months) + "-" + bills.getNumber(date.getDate());
        return (date.getFullYear() - 1) + "-" + bills.getNumber(12 - months + month) + "-" + bills.getNumber(date.getDate());
    },

    getNumber(number) {
        return number > 9 ? number : "0" + number
    },

    openView(id) {
        var btn1 = function (index) {
            var body = layer.getChildFrame('body', index);
            $.post("/Bills/EditData", {
                Id: body.find("#Id").val(),
                Money: body.find("#Money").val(),
                UpdateTime: body.find("#UpdateTime").val(),
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
        layerHelper.open(id ? "修改" : "新增", "/Bills/Edit?id=" + id, 2, ["400px", "500px"], ["确认", "取消"], [btn1, btn2])
    }
};