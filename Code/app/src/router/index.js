import Vue from 'vue'
import Router from 'vue-router'
import Home from '../components/Home'

Vue.use(Router)

const router = new VueRouter({
    router: [
        {
            path: '/',
            component: Home,
            meta: {
                ShowFooterBar: true
            }
        },
        {
            path: '/HelloWorld',
            name: 'HelloWorld',
            component(resolve) {
                require(['@/components/HelloWorld'], resolve);
            }
        },
    ]
})