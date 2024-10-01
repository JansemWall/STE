
<script setup>
import Navbar from '../components/Navbar.vue';
import Footer from '../components/Footer.vue';
import CardAdm from '@/components/CardAdm.vue';
</script>

<template>
<Navbar />
<CardAdm />
<RouterView />
<Footer></Footer>
</template>

<style>
@media (min-width: 1024px) {
  .about {
    justify-content: center;     /* Centraliza horizontalmente */
    align-items: center;         /* Centraliza verticalmente (se necessário) */
    min-height: calc(80vh - 160px);
  }
}
</style>
