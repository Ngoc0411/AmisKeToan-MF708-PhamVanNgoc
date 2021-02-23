import Router from 'vue-router';
import Vue from 'vue'
import Employee from './components/Employee/Employee';

Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: '/',
      component: Employee,
    },
    {
      path: '/quan-li-nhan-vien',
      component: Employee,
    },
    
  ]
})
