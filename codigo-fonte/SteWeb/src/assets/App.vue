<script >
import { RouterLink, RouterView } from 'vue-router'
import 'vue3-toastify/dist/index.css';
import { toast } from 'vue3-toastify';
import Footer from '@/components/Footer.vue';
</script>

<template>
  <!-- Colocar Component Header com navegação bacana -->
  <!-- RouterView  passando tudo das views, atualmente apenas HomeView-->
          <RouterView />
          <Footer></Footer>
</template>

<style scoped> </style>