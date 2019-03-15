import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../components/Home.vue'

Vue.use(VueRouter)

export default new VueRouter({
    router: [
        {
            path: '/',
            component: Home,
            meta: {
                ShowFooterBar: true
            }
        }
    ]
})