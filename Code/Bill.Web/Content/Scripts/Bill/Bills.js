﻿$(function () {
    bills.events();
})

var bills = {
    index: 1,
    size: 15,
    data: null,
    count: 0,
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
        this.getData();
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
    },

    layer() {
        layui.use(['laydate', 'laypage', 'layer','table'], function () {
            var laydate = layui.laydate,
                laypage = layui.laypage,
                layer = layui.layer,
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
                //, height: 312
                //, url: '/Bills/FindList' //数据接口
                , page: true //开启分页
                , cols: [[ //表头
                    { field: 'id', title: 'ID', width: 80, sort: true, fixed: 'left' }
                    , { field: 'BillsTypeName', title: '账单类型', width: 80 }
                    , { field: 'Money', title: '金额', width: 80 }
                    , { field: 'Describe', title: '详情', width: 80 }
                    , { field: 'UpdateTime', title: '创建时间', width: 177 }
                ]]
                , data: bills.data
            });
            $.post("/Bills/Count", {}, function () { })
            //分页加载
            laypage.render({
                elem: 'Page'
                , count: bills.count
                , layout: ['count', 'prev', 'page', 'next', 'limit', 'refresh', 'skip']
                , jump: function (obj) {
                    bills.index++;
                    getData();
                    table.reload("Table", { //此处是上文提到的 初始化标识id
                        where: {
                            //key: { //该写法上文已经提到
                            type: item.type, id: item.id
                            //}
                        }
                    });
                }
            });


        });
    },

    getData() {
        $.post("/Bills/FindList", {
            StartDateTime: $("#StartDateTime").val(),
            EndDateTime: $("#EndDateTime").val(),
            BillsTypeId: $("#BillsTypeId").val(),
            Pagination: {
                Page: bills.index,
                Rows: bills.size
            }
        }, function (res) {
            bills.data = res.Data;
            bills.count = res.Total;
        })
    }
};