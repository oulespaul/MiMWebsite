import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify';
import VueRouter from 'vue-router';
import index from '@/Views/index.vue';
import createMim from '@/Views/createMim.vue';
import dashboard from '@/Views/dashboard.vue';
import transactionDashboard from '@/Views/transactionDashboard'
import Vuelidate from 'vuelidate'
Vue.use(Vuelidate)


Vue.config.productionTip = false

Vue.use(VueRouter)

const routes = [
  {path: '/', component: index},
  {path: '/createMim', component: createMim},
  {path: '/dashboard', component: dashboard},
  {path: '/transaction', name:'trx', component: transactionDashboard, props: true}
]
const router = new VueRouter({
  routes
})


new Vue({
  vuetify,
  router,
  render: h => h(App)
}).$mount('#app')
