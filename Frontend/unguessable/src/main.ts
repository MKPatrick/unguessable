import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
import Start from './pages/StartPage.vue';
import Play from './pages/Play.vue';
import CategorySelection from './pages/CategorySelection.vue';
import App from './App.vue'
import './style.css'

// 2. Define some routes
// Each route should map to a component.
// We'll talk about nested routes later.
const routes = [
    { path: '/', component: Start },
    { path: '/Play:categories', component: Play, name:'Play' },
    { path: '/CategorySelection', component: CategorySelection },
  ]

  // 3. Create the router instance and pass the `routes` option
  // You can pass in additional options here, but let's
  // keep it simple for now.
  const routers = createRouter({
    // 4. Provide the history implementation to use. We are using the hash history for simplicity here.
    history: createWebHistory(),
    routes, // short for `routes: routes`
  })

  const app = createApp(App)

// Make sure to _use_ the router instance to make the
// whole app router-aware.
app.use(routers)

app.mount('#app')