<template>
    <!-- Menu -->
    <div class="navbar">
        <div class="navbar-left">
            <!-- Logo e saudação -->
            <img src="https://via.placeholder.com/40" alt="Logo">
            <span>Olá User, Seja Bem Vindo(a)</span>
        </div>
        <div class="navbar-right"> 
            <!-- Links e barra de busca -->
            <a href="#">Perfil Administrativo</a>
            <a href="#">Ajuda</a>
            <div class="search-bar">
                <input type="text" placeholder="Ajuda">
                <button>
                    <img src="https://via.placeholder.com/20" alt="Pesquisar">
                </button>
            </div>
            <!-- Botão de Logout -->
            <a href="#" @click.prevent="handleLogout">Sair</a>
        </div>
    </div>
</template>

<script setup>
// Importa a função de logout
import { logout } from '@/services/auth';

const handleLogout = () => {
    // Chama a função de logout e redireciona o usuário
    logout();
};
</script>

<style scoped>
body {
    margin: 0;
    font-family: Arial, sans-serif;
}

/* Estilização da barra de navegação */
.navbar {
    background-color: #1D5773; /* Azul marinho */
    padding: 15px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    color: white;
    position: fixed; /* Mantém o navbar fixo */
    top: 0;         /* Fica na parte superior */
    left: 0;        /* Fica alinhado à esquerda */
    width: 100%;    /* Largura total da tela */
    z-index: 1000; /* Garante que fique acima de outros elementos */
}

/* Estilização do logo e saudação */
.navbar-left {
    display: flex;
    align-items: center;
}

.navbar-left img {
    width: 40px;
    height: 40px;
    border-radius: 50%;
    margin-right: 10px;
}

.navbar-left span {
    font-size: 18px;
}

/* Links do lado direito */
.navbar-right {
    display: flex;
    align-items: center;
}

.navbar-right a {
    color: white;
    margin-right: 20px;
    text-decoration: none;
    font-size: 16px;
}

.navbar-right a:hover {
    text-decoration: underline;
}

/* Estilização da barra de busca */
.search-bar {
    display: flex;
    align-items: center;
    background-color: white;
    padding: 5px;
    border-radius: 5px;
}

.search-bar input {
    border: none;
    padding: 5px;
    border-radius: 5px;
    outline: none;
}

.search-bar button {
    background: none;
    border: none;
    cursor: pointer;
}

.search-bar button img {
    width: 20px;
    height: 20px;
}

/* Estilos do modal (caso existam no mesmo componente) */
.modalOverlay {
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: rgba(0, 0, 0, 0.5);
    display: flex;
    justify-content: center;
    align-items: center;
}

.modal {
    background: white;
    border-radius: 10px;
    padding: 20px;
    width: 90%;
    max-width: 600px;
    position: relative;
}

.close {
    position: absolute;
    top: 10px;
    right: 10px;
    font-size: 24px;
    cursor: pointer;
}

.modalContent {
    margin-top: 20px;
}
</style>
