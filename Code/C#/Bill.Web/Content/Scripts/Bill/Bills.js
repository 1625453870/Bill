$(function () {
    bills.events();
})

var bills = {
    events() {
        $("#CreateTime a").click(function () {
            $("#StartDateTime").attr("value", bills.getTime($(this).attr("name")));
            $("#CreateTime a").removeClass("bills_selected");
            $(this).addClass("bills_selected");
            bills.layer();
        });

        $("#BillsType a").click(function () {
            $("#BillsType a").removeClass("bills_selected");
            $(this).addClass("bills_selected");
            $("#BillsTypeId").val($(this).attr("name"));
            bills.layer();
        })

        $("#Add").click(function () {
            bills.openView();
        })


        this.layer();
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
                BillsTypeId: body.find("#BillsTypeId").val(),
                Money: body.find("#Money").val(),
                UpdateTime: body.find("#UpdateTime").val(),
                Describe: body.find("#Describe").val(),
            }, function () {
                layer.msg(!id ? '创建成功！' : "修改成功", { icon: 6 });
            })
            layer.close(index);
            bills.layer();

        }
        var btn2 = function (index) { }
        layerHelper.open(id ? "修改" : "新增", "/Bills/Edit?id=" + id, 2, ["400px", "500px"], ["确认", "取消"], [btn1, btn2])
    },

    layer() {
        layui.use(['laydate', 'table'], function () {
            var laydate = layui.laydate,
                table = layui.table;

            //执行一个laydate实例
            laydate.render({
                elem: '#StartDateTime' //指定元素
            });
            laydate.render({
                elem: '#EndDateTime' //指定元素
            });

            //表格加载
            table.render({
                elem: '#Table '
                , method: "post"
                //, height: 312
                , url: '/Bills/FindList' //数据接口
                , page: true //开启分页
                , where: {
                    StartDateTime: $("#StartDateTime").val(),
                    EndDateTime: $("#EndDateTime").val(),
                    BillsTypeId: $("#BillsTypeId").val(),
                    Pagination: {
                        Page: 'curr',
                        Rows: 15
                    }
                }
                , cols: [[ //表头
                    { field: 'BillsTypeName', title: '账单类型', width: "15%" }
                    , { field: 'Money', title: '金额', width: "15%" }
                    , { field: 'Describe', title: '详情', width: "30%" }
                    , { field: 'DateTime', title: '创建时间', width: "25%" }
                    , { fixed: 'right', title: '操作', toolbar: '#0peration', width: "15%" }
                ]]
            });

            table.on('tool(table)', function (obj) {
                var data = obj.data;

                console.log(data);
                if (obj.event === 'del') {
                    layer.confirm('真的删除数据吗，该操作不可回执？', function (index) {
                        $.get("/Bills/Delete?id=" + data.Id, function () {
                            obj.del();
                            layer.close(index);
                        })

                    });
                } else if (obj.event === 'edit') {
                    bills.openView(data.Id);
                }
            });


        });
    },


};