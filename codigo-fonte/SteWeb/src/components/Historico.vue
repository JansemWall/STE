<template>
    <div class="bg-white rounded-2xl py-4 px-6">
        <div v-if="loading" class="flex justify-center items-center">
            <span>Carregando...</span>
        </div>

        <div v-else>
            <h1 class="text-2xl font-semibold pb-5">Histórico de Empréstimos</h1>

            <div v-if="error" color="red" class="mb-4">Erro ao carregar histórico de empréstimos.</div>

            <p v-if="!error && historico.length === 0" class="text-center mb-4">
                Nenhum empréstimo encontrado.
            </p>

            <table v-else highlightOnHover>
                <thead>
                    <tr>
                        <th class="pb-2 pt-1">Item</th>
                        <th class="pb-2 pt-1">Cod. Item</th>
                        <th class="pb-2 pt-1">Aluno</th>
                        <th class="pb-2 pt-1">Cod. de Pessoa</th>
                        <th class="pb-2 pt-1">Data de Empréstimo</th>
                        <th class="pb-2 pt-1">Data de Devolução</th>
                    </tr>
                </thead>
                <tbody class="text-center">
                    <tr v-for="history in historico" :key="history.id" class="hover:bg-gray-300">
                        <td class="p-1">{{ history.itemName }}</td>
                        <td class="p-1">{{ history.itemCode }}</td>
                        <td class="p-1">{{ history.studentName }}</td>
                        <td class="p-1">{{ history.studentId }}</td>
                        <td class="p-1">{{ new Date(history.dateLend).toLocaleDateString() }}</td>
                        <td class="p-1">{{ history.dateReturn ? new Date(history.dateReturn).toLocaleDateString() : 'Não devolvido'}}</td>
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

</style>