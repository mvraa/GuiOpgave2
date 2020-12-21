import Vue from 'vue'
import App from './App.vue'
import router from './router'
import { store } from './store/store'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import moment from 'moment'
Vue.use(BootstrapVue)

Vue.config.productionTip = false;

Vue.filter('formatDate', function (value) {
    if (value) {
        return moment(String(value)).format('MM/DD/YYYY hh:mm')
    }
});

new Vue({
    router,
    store,
    render: h => h(App)
}).$mount('#app');
