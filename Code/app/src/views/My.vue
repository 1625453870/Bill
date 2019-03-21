<!--  -->
<template>
  <div>
    <mt-header>
      <mt-button icon="more" slot="left">
        <mt-button>我的</mt-button>
      </mt-button>
      <mt-button icon="more" slot="right">
        <mt-button @click="handleClose">设置</mt-button>
      </mt-button>
    </mt-header>
    <div class="head">
      <div class="padding_10px">
        <div class="float_left">
          <img class="head_img" src="../assets/img/my.png">
        </div>
        <div class="my_info">
          <div>+66</div>
          <div class="phone">184******29</div>
        </div>
        <div class="float_right img_right">
          <img src="../assets/img/jiantou.png">
        </div>
      </div>
      <div></div>
    </div>
    <div>12</div>
  </div>
</template>

<script>
export default {
  data() {
    return {};
  },
  //方法集合
  methods: {},
  //监听属性 类似于data概念
  computed: {},
  //监控data中的数据变化
  watch: {}
};
</script>
<style scoped>
.head {
  height: 82px;
  background-color: #26a2ff;
}
.head_img {
  border: 3px solid #26b9ffd1;
  border-radius: 7px;
  width: 50px;
}
.my_info {
  float: left;
  position: relative;
  height: 60px;
  padding-left: 10px;
  color: #fff;
  width: 112px;
}
.my_info .phone {
  position: absolute;
  bottom: 7px;
  background-color: #ffffff4a;
  padding: 5px 11px;
  border-radius: 30px;
  font-size: 12px;
}
.img_right {
  line-height: 4;
}
.img_right img{
    
  width: 25px;
}
</style>