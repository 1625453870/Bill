import Vue from 'vue';
//引入mint-ui
import { Tabbar, TabItem, Header } from 'mint-ui';

import 'mint-ui/lib/style.css';
import '../src/assets/css/main.css';

export const initPlugins = function () {
    Vue.component(Tabbar.name, Tabbar);
    Vue.component(TabItem.name, TabItem);
    Vue.component(Header.name, Header);
}