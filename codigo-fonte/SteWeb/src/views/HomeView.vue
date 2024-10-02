<script setup>
import Navbar from '../components/Navbar.vue';
import Cards from '../components/Cards.vue';
</script>

<template>
    <Navbar></Navbar>
    <div class="container">
        <Cards></Cards>
        <RouterView />
    </div>
</template>

<style scoped>
.container {
    justify-content: center;     /* Centraliza horizontalmente */
    align-items: center;         /* Centraliza verticalmente (se necessário) */
    min-height: calc(80vh - 160px); /* Ajuste a altura mínima (substitua 160px pela altura do Navbar e Footer se necessário) */
}
</style>
