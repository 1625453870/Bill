<!--  -->
import func from './vue-temp/vue-editor-bridge';
<template>
  <div>
    <mt-tabbar v-model="selected" class="mint-tabbar-border">
      <mt-tab-item id="home">
        <img slot="icon" :src="img1">
        首页
      </mt-tab-item>
      <mt-tab-item id="my">
        <img slot="icon" :src="img2">
        我的
      </mt-tab-item>
    </mt-tabbar>
  </div>
</template>

<script>
export default {
  data() {
    return {
      selected: "",
      img1: require("../assets/img/home_select.png"),
      img2: require("../assets/img/my.png")
    };
  },
  //方法集合
  methods: {},
  //监听属性 类似于data概念
  computed: {},
  //监控data中的数据变化
  watch: {
    selected: function() {
      if (this.selected === "home") {
        this.$router.push("/home");
        this.img1 = require("../assets/img/home_select.png");
      } else this.img1 = require("../assets/img/home.png");
      if (this.selected === "my") {
        this.$router.push("/my");
        this.img2 = require("../assets/img/my_select.png");
      } else this.img2 = require("../assets/img/my.png");
    }
  }
};
</script>
<style scoped>
.mint-tabbar-border {
  border-top: 1px solid #e0dada;
  background-color: #fff;
}
.is-selected {
  background-color: #fff !important;
}
</style>