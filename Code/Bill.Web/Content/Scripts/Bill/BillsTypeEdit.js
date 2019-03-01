layui.use('upload', function () {
    var upload = layui.upload;

    //执行实例
    var uploadInst = upload.render({
        elem: '#Logo' //绑定元素
        , url: '../Upload/FilesUpload?type=1' //上传接口
        , done: function (res) {
            $("#Logo").attr("src", res.data.src);
        }
        , error: function () {
            //请求异常回调
        }
    });
});
