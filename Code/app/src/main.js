import Vue from 'vue'
import App from './App.vue'
import router from './router/index';
import {Tabbar, TabItem} from 'mint-ui';
import { Button } from 'mint-ui';
import { Header } from 'mint-ui';
import { Cell } from 'mint-ui';
import { Swipe, SwipeItem } from 'mint-ui';
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
  render: h => h(App)
}).$mount('#app')
