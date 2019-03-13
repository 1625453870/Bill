import Vue from 'vue'
import 'mint-ui/lib/style.css'
import App from './App.vue'
import router from './router/index';


Vue.config.productionTip = false
Vue.component(Tabbar.name, Tabbar);
Vue.component(TabItem.name, TabItem);
Vue.component(Button.name, Button);
Vue.component(Header.name, Header);
Vue.component(Swipe.name, Swipe);
Vue.component(SwipeItem.name, SwipeItem);
Vue.component(Cell.name, Cell);

new Vue({
  router,
  el: '#app',
  components: { App }
})



