import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter);

const routes = [
    {
        path: '/',
        name: 'Home',
        component: () => import('../views/Home.vue')
    },
    {
        path: '/login',
        name: 'Login',
        component: () => import('../views/Login.vue')
    },
    {
        path: '/jobs',
        name: 'Jobs',
        component: () => import('../views/Jobs.vue')
    },
    {
        path: '/create',
        name: 'Create',
        component: () => import('../views/Create.vue')
    }
]

const router = new VueRouter({
    routes
});

export default router