<script setup>
import Navbar from '../components/Navbar.vue';
import Cards from '../components/Home.vue';
import BreadCrumbs from '@/components/comps/BreadCrumbs.vue';
</script>

<template>
    <Navbar />
    <BreadCrumbs />
    <div class="container">        
        <RouterView class="children"/>
    </div>
</template>

<style scoped>
.container {
    display: flex;
    justify-content: center;
    /* Centraliza horizontalmente */
    /* Centraliza verticalmente (se necessário) */
    min-height: calc(80vh - 160px);
    /* Ajuste a altura mínima (substitua 160px pela altura do Navbar e Footer se necessário) */
    min-width: max-content;
}

</style>
