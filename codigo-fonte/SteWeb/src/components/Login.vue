<template>
    <section class="vh-100 gradient-custom">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                    <div class="card bg-dark text-white" style="border-radius: 1rem;">
                        <form class="card-body p-5 text-center" @submit.prevent="handleLogin">
                            <div class="mb-md-5 mt-md-4">
                                <div class="flex justify-center my-4">
                                    <a href="/" class="flex flex-column justify-center">
                                        <img :src="logo" alt="CRC Empresta" class="h-10 flex justify-center">
                                        <p>CRC Empresta</p>
                                    </a>
                                </div>
                                <h2 class="fw-bold mx-4 text-uppercase">
                                    Entrar
                                </h2>
                                <p class="text-white-50 mb-5">
                                    Insira seu usuário e senha!
                                </p>

                                <div data-mdb-input-init class="form-outline form-white mb-4">
                                    <input id="typeEmailX" v-model="name" type="text" placeholder="Usuário" required
                                        class="form-control form-control-lg">
                                </div>

                                <div data-mdb-input-init class="form-outline form-white mb-4">
                                    <input id="typePasswordX" v-model="password" type="password" placeholder="Senha"
                                        required class="form-control form-control-lg">
                                </div>
                                <button data-mdb-button-init data-mdb-ripple-init
                                    class="btn btn-outline-light btn-lg px-5" type="submit">
                                    Login
                                </button>
                            </div>

                            <div>
                                <p class="mb-0">
                                    <a href="/cadastro" class="text-white-50 fw-bold">Cadastro</a>
                                </p>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>
</template>

<script>
import { login } from '@/services/auth';
export default {
    data() {
        return {
            name: '',
            password: ''
        }
    },
    methods: {
        async handleLogin() {
            try {
                await login(this.name, this.password);
                // toast.success('Login com sucesso!', { autoClose: 1000 });
                this.$router.push('/');
            } catch (error) {
                // toast.error('Usuário ou senha inválido!', { autoClose: 1000 });
                console.error('Erro ao fazer login', error);
            }
        }
    }
}
</script>

<style scoped></style>