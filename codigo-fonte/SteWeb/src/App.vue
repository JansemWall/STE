<script >
import { RouterLink, RouterView } from 'vue-router'
import 'vue3-toastify/dist/index.css';
import { toast } from 'vue3-toastify';
import Footer from '@/components/Footer.vue';
</script>

<template>
  <!-- Colocar Component Header com navegação bacana -->
  <!-- RouterView  passando tudo das views, atualmente apenas HomeView-->
  <transition name="slide-fade" mode="out-in">
          <RouterView />
  </transition>
          <Footer></Footer>
</template>

<style scoped> 
.slide-fade-enter-active, .slide-fade-leave-active {
  transition: all 1.6s ease; 
}

.slide-fade-enter, .slide-fade-leave-to {
  opacity: 0;
  transform: translateX(50px); 
}

.slide-fade-leave-active {
  transform: translateX(-50px); 
  opacity: 0;
}
</style>