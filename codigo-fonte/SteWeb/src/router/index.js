import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '../views/HomeView.vue';
import Login from '@/components/Login.vue';
import Emprestar from '@/components/Emprestar.vue';
import Devolver from '@/components/Devolver.vue';
import Historico from '@/components/Historico.vue';
import Cookies from 'js-cookie';
import AdminView from '@/views/AdminView.vue';
import CrudCategoria from '@/components/CrudCategoria.vue';
import Home from '@/components/Home.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/admin',
      name: 'admin',
      component: AdminView,
      meta: { requiresAuth: true },
      children: [
        { path: '/categoria', component: CrudCategoria, name: 'categoria', meta: { requiresAuth: true } },
      ]
    },
    {
      path: '/',
      component: HomeView,
      meta: { requiresAuth: true },
      children: [
        { path: '/', component: Home, name: 'Home', meta: { requiresAuth: true }},
        { path: '/emprestar', component: Emprestar, name: 'emprestar', meta: { requiresAuth: true , breadcrumb: 'Empréstimo' }},
        { path: '/devolver', component: Devolver, name: 'devolver', meta: { requiresAuth: true , breadcrumb: 'Devolução'  } },
        { path: '/historico', component: Historico, name: 'historico', meta: { requiresAuth: true , breadcrumb: 'Histórico' } },
      ]
    }
  ]
});

// Navigation Guard para verificar autenticação
router.beforeEach((to, from, next) => {
  // Verifica se a rota requer autenticação
  if (to.matched.some(record => record.meta.requiresAuth)) {
    const token = Cookies.get('access_token'); // Verifica se o token está nos cookies
    if (!token) {
      // Se não houver token, redireciona para a página de login
      next({ name: 'login' });
    } else {
      next(); // Se houver token, permite a navegação
    }
  } else {
    next(); // Se a rota não requer autenticação, permite a navegação
  }
});

export default router;
