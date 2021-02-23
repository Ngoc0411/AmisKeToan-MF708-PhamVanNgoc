import Vue from 'vue'
import App from './App.vue'
import router from './router' ;

Vue.config.productionTip = false

new Vue({
  render: h => h(App),
  router
}).$mount('#app')

// function formatGender(gender) {
//   switch (gender) {
//       case 0:
//           return "Nữ";
//       case 1:
//           return "Nam";
//       case 2:
//           return "Khác";
//       default:
//           break;
//   }
// }

