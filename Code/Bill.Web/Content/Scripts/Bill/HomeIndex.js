$(function () {
    if (cookieHelper.getCookie("Name")) {
        homeIndex.setHtml();
    } else {
        homeIndex.login();
    }
    homeIndex.events();
    
})

var homeIndex = {
    events() {
        $("#Exit").click(function () {
            layer.confirm('确认退出？', { icon: 3, title: '提示' }, function (index) {
                cookieHelper.delCookie();
                location.reload();
            });
       
        });
    },
    setHtml() {
        var logo = $("#logo").parent("a");
        var logoData = cookieHelper.getCookie("Logo")
        var html = '<img src="' + (logoData ? logoData : "http://t.cn/RCzsdCq") + '" class="layui-nav-img" id="logo">' + cookieHelper.getCookie("NickName")
        logo.html(html);
        this.chart_circle_left();
        this.chart_circle_rigth();
    },
    login() {
        var btn1 = function (index, layero) {
            var body = layer.getChildFrame('body', index);
            $.post("/Login/LoginUser", { Name: body.find("#Name").val(), Pwd: body.find("#Pwd").val() },
                function (data) {
                    if (data.Id) {
                        layer.close(index);
                        layer.msg('登录成功！', { icon: 6 });
                        cookieHelper.setUserCookie(data);
                        homeIndex.setHtml();
                    }
                    else
                        layer.msg('登录失败！', { icon: 5 });
                })

        };
        var btn2 = function (index, layero) {
            layer.close(index);
            homeIndex.register();
        }
        layerHelper.open("登录", "/Login/Login", 2, ["400px", "300px"], ["登陆", "注册"], [btn1, btn2])
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
                        layer.close(index);
                        layer.msg('登录成功！', { icon: 6 });
                        cookieHelper.setUserCookie(data);
                        homeIndex.setHtml();
                    }
                    else
                        layer.msg('注册失败！', { icon: 5 });
                })
            layer.close(index);
        };
        var btn2 = function (index, layero) {
            layer.close(index);
            layerHelper.login();
        }
        layerHelper.open("注册", "/Login/Register", 2, ["400px", "350px"], ["确认", "返回登陆"], [btn1, btn2])
    },
    chart_circle_left() {
        var myChart = echarts.init(document.getElementById("container_left"));
        $.post("/Bills/GetNowMonth_Left", function (res) {

            var legendData = [];
            var seriesData = [];
            var selected = {};
            var money = 0;
            for (var item in res) {
                legendData.push(item);
                selected[item] = true;
                seriesData.push({
                    name: item,
                    value: res[item]
                });

                money += res[item]
            }
            option = {
                title: {
                    text: '月消费：' + money + "￥",
                    x: 'center'
                },
                tooltip: {
                    trigger: 'item',
                    formatter: "{b} : {c}￥ ({d}%)"
                },
                legend: {
                    type: 'scroll',
                    orient: 'vertical',
                    right: 10,
                    top: 20,
                    bottom: 20,
                    data: legendData,

                    selected: selected
                },
               
                series: [
                    {
                        name: '姓名',
                        type: 'pie',
                        radius: '55%',
                        center: ['40%', '50%'],
                        data: seriesData,
                        itemStyle: {
                            emphasis: {
                                shadowBlur: 10,
                                shadowOffsetX: 0,
                                shadowColor: 'rgba(0, 0, 0, 0.5)'
                            }
                        },
                        label: {
                            normal: {
                                formatter: '{c}',
                                position: 'inside'
                            }
                        },
                    }
                ]
            };
            if (option && typeof option === "object") {
                myChart.setOption(option, true);
            }
        })
    },
    chart_circle_rigth() {
        var myChart = echarts.init(document.getElementById("container_rigth"));
        var app = {};
        option = null;
        var cellSize = [80, 80];
        var pieRadius = 30;
        $.post("/Bills/GetNowMonth_Rigth", function (res) {
            var _date = new Date();
            var date = +echarts.number.parseDate(_date.getFullYear() + "-" + (_date.getMonth() + 1) + "-01");
            var end = +echarts.number.parseDate(_date.getFullYear() + "-" + (_date.getMonth() + 2) + "-01");
            var dayTime = 3600 * 24 * 1000;
            var scatterData = [];
            for (var time = date; time < end; time += dayTime) {
                scatterData.push([
                    echarts.format.formatTime('yyyy-MM-dd', time),
                    Math.floor(Math.random() * 10000)
                ]);
            }

            function getPieSeries(scatterData, chart) {
                return echarts.util.map(scatterData, function (item, index) {
                    var center = chart.convertToPixel('calendar', item);
                    var data = res[item[0]];
                    var seriesData = [];
                    for (var item in data) {
                        seriesData.push({
                            name: item,
                            value: data[item]
                        });
                    }
                    return {
                        id: index + 'pie',
                        type: 'pie',
                        center: center,
                        label: {
                            normal: {
                                formatter: '{c}',
                                position: 'inside'
                            }
                        },
                        radius: pieRadius,
                        data: seriesData
                    };
                });
            }

            function getPieSeriesUpdate(scatterData, chart) {
                return echarts.util.map(scatterData, function (item, index) {
                    var center = chart.convertToPixel('calendar', item);
                    return {
                        id: index + 'pie',
                        center: center
                    };
                });
            }


            option = {
                tooltip: {},

                calendar: {
                    top: 'middle',
                    left: 'center',
                    orient: 'vertical',
                    cellSize: cellSize,
                    yearLabel: {
                        show: false,
                        textStyle: {
                            fontSize: 30
                        }
                    },
                    dayLabel: {
                        margin: 20,
                        firstDay: 1,
                        nameMap: ['星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六']
                    },
                    monthLabel: {
                        show: false
                    },
                    range: ['2019-03']
                },
                series: [{
                    id: 'label',
                    type: 'scatter',
                    coordinateSystem: 'calendar',
                    symbolSize: 1,
                    label: {
                        normal: {
                            show: true,
                            formatter: function (params) {
                                return echarts.format.formatTime('dd', params.value[0]);
                            },
                            offset: [-cellSize[0] / 2 + 10, -cellSize[1] / 2 + 10],
                            textStyle: {
                                color: '#000',
                                fontSize: 14
                            }
                        }
                    },
                    data: scatterData
                }]
            };

            if (!app.inNode) {
                var pieInitialized;
                setTimeout(function () {
                    pieInitialized = true;
                    myChart.setOption({
                        series: getPieSeries(scatterData, myChart)
                    });
                }, 10);

                app.onresize = function () {
                    if (pieInitialized) {
                        myChart.setOption({
                            series: getPieSeriesUpdate(scatterData, myChart)
                        });
                    }
                };
            };
            if (option && typeof option === "object") {
                myChart.setOption(option, true);
            }
        })

    }
};
