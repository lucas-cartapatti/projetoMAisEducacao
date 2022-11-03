import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import VMask from '@devindex/vue-mask'

const app = createApp(App);
app.use(router);
app.use(VMask);
app.mount('#app');

 
