<template>
    <div class="bg-white rounded-2xl py-4 px-6">
        <div v-if="loading" class="flex justify-center items-center">
            <span>Carregando...</span>
        </div>

        <div v-else>
            <h2 class="text-2xl font-semibold pb-5">Histórico de Empréstimos</h2>

            <div v-if="error" color="red" class="mb-4">Erro ao carregar histórico de empréstimos.</div>

            <p v-if="!error && historico.length === 0" class="text-center mb-4">
                Nenhum empréstimo encontrado.
            </p>

            <table v-else highlightOnHover class="bordinha">
                <thead >
                    <tr class="text-center border ">
                        <th class="p-2 pt-1">Item</th>
                        <th class="p-2 pt-1 border">Cod. Item</th>
                        <th class="p-2 pt-1 border">Aluno</th>
                        <th class="p-2 pt-1 border">Cod. de Pessoa</th>
                        <th class="p-2 pt-1 border">Data de Empréstimo</th>
                        <th class="p-2 pt-1">Data de Devolução</th>
                    </tr>
                </thead>
                <tbody class="text-center">
                    <tr v-for="history in historico" :key="history.id" class="linhaTabela">
                        <td class="p-1 border">{{ history.itemName }}</td>
                        <td class="p-1 border">{{ history.itemCode }}</td>
                        <td class="p-1 border">{{ history.studentName }}</td>
                        <td class="p-1 border">{{ history.studentId }}</td>
                        <td class="p-1 px-4 border">{{ new Date(history.dateLend).toLocaleDateString() }} {{ new Date(history.dateLend).toLocaleTimeString() }}</td>
                        <td class="p-1 px-4 border">{{ history.dateReturn ? new Date(history.dateReturn).toLocaleDateString() + ' ' + new Date(history.dateReturn).toLocaleTimeString() : 'Não devolvido'}}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
import api from '@/services/api'

export default {
    name: 'Historico',
    data() {
        return {
            historico: [],
            loading: true,
            error: false,
        }
    },
    created() {
        this.getHistorico()
    },
    methods: {
        getHistorico() {
            api.get('LendingManager/History')
                .then(response => {
                    this.historico = response.data
                })
                .catch(() => {
                    this.error = true
                })
                .finally(() => {
                    this.loading = false
                })
        },
    },
}
</script>

<style scoped>
.linhaTabela:hover {
    background-color: #f4f4f4;
}
</style>