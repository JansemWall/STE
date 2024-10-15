<template>
    <section class="vh-100 gradient-custom d-flex align-items-center justify-content-center">
        <div class="login-box">
            <div class="text-center my-4">
                <a href="/">
                    <img :src="logo" alt="Sistema de Empréstimo" class="logo-img">
                </a>
            </div>
            <form class="p-2 text-center" @submit.prevent="handleLogin">
                <div data-mdb-input-init class="form-outline form-white mb-4">
                    <div class="user-box">
                        <input id="typeEmailX" v-model="name" type="text" required class="form-control form-control-lg">
                        <label>Usuário</label>
                    </div>
                </div>
                <div data-mdb-input-init class="form-outline form-white mb-4">
                    <div class="user-box">
                        <input id="typePasswordX" v-model="password" type="password" required class="form-control form-control-lg">
                        <label>Senha</label>
                    </div>
                </div>
                <div>
                    <button type="submit" class="btn btn-outline-dark btn-lg px-5 fw-bold" :disabled="isLoading">
                        <span v-if="!isLoading">Login</span>
                        <span v-else>
                            <img src="@/assets/loading.svg" alt="Loading..." class="loading-icon">
                        </span>
                    </button>
                </div>
            </form>
        </div>
    </section>
</template>

<script>
import { login } from '@/services/auth';
import { toast } from 'vue3-toastify';
import logo from '@/assets/logo.svg';

export default {
    data() {
        return {
            name: '',
            password: '',
            isLoading: false,
            logo
        }
    },
    methods: {
        async handleLogin() {
            this.isLoading = true;
            try {
                await login(this.name, this.password);
                toast.success('Login com sucesso!', { autoClose: 1000 });
                this.$router.push('/');
            } catch (error) {
                toast.error('Usuário ou senha inválido!', { autoClose: 1000 });
                console.error('Erro ao fazer login', error);
            } finally {
                this.isLoading = false;
            }
        }
    }
}
</script>

<style scoped>
html, body {
    height: 100%;
    margin: 0;
    font-family: Arial, sans-serif;
}

.vh-100 {
    height: 100vh;
}

.centralizar {
    display: flex;
    flex-direction: column;
    justify-content: center;
    text-decoration: none;
}

.logo-img {
    width: 300px;
    height: auto;
}

.login-box {
    width: 400px;
    padding: 20px;
    background: #fff;
    box-shadow: 0 15px 25px rgba(0, 0, 0, 0.2);
    border-radius: 10px;
    text-align: center;
}

.user-box {
    position: relative;
    margin-bottom: 30px;
}

.user-box input {
    width: 100%;
    padding: 10px 0;
    font-size: 16px;
    color: #000;
    border: none;
    border-bottom: 1px solid #000;
    outline: none;
    background: transparent;
}

.user-box label {
    position: absolute;
    top: 10px;
    left: 0;
    font-size: 16px;
    color: #000;
    pointer-events: none;
    transition: 0.5s;
}

.user-box input:focus ~ label,
.user-box input:valid ~ label {
    top: -20px;
    font-size: 12px;
    color: #004062;
}

.btn[disabled] {
    opacity: 0.6;
    cursor: not-allowed;
}

.loading-icon {
    width: 20px;
    height: 20px;
    animation: spin 1s linear infinite;
}

@keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
}
</style>
