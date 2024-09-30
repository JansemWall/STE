import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Login from '@/components/Login.vue';
import Emprestar from '@/components/Emprestar.vue';
import Devolver from '@/components/Devolver.vue';
import Historico from '@/components/Historico.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/',
      component: HomeView,
      meta: { },
      children: [
          { path: '/emprestar', component: Emprestar, name: 'emprestar' },
          { path: '/devolver', component: Devolver, name: 'devolver' },
          { path: '/historico', component: Historico, name: 'historico' },
      ]
  },
  ]
})

export default router
