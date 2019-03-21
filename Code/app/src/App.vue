<template>
  <div id="app">
    <router-view/>
    <FooterBar></FooterBar>
  </div>
</template>
<script>
// 1296db
import FooterBar from './components/FooterBar.vue'
export default {
  name:'app',
  components:{FooterBar}
};
</script>
