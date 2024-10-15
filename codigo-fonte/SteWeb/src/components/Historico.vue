<template>
    <div class="bg-white rounded-2xl py-4 px-6">
        <div v-if="loading" class="flex justify-center items-center">
            <span>Carregando...</span>
        </div>

        <div v-else>
            <h2 class="text-2xl font-semibold pb-5">Histórico de Empréstimos</h2>

            <div v-if="error" color="red" class="mb-4">Erro ao carregar histórico de empréstimos.</div>

            <p v-if="!error && historicoFiltrado.length === 0" class="text-center mb-4">
                Nenhum empréstimo encontrado.
            </p>

            <!-- Filtros -->
            <div class="mb-4">
                <input v-model="filterNameOrCode" placeholder="Filtrar por nome ou código da pessoa" class="border px-2 py-1 rounded mr-2" />
                <label for="dateFrom">De:</label>
                <input v-model="filterDateFrom" type="date" class="border px-2 py-1 rounded ml-1 mr-2" />
                <label for="dateTo">Até:</label>
                <input v-model="filterDateTo" type="date" class="border px-2 py-1 rounded ml-1" />
                <button @click="applyFilters" class="bg-blue-500 text-black px-4 py-2 rounded ml-2">Filtrar</button>
                <button @click="clearFilters" class="bg-gray-500 text-black px-4 py-2 rounded ml-2">Limpar</button>
            </div>

            <table v-if="paginatedData.length > 0" highlightOnHover class="bordinha">
                <thead>
                    <tr class="text-center border">
                        <th class="p-2 pt-1">Item</th>
                        <th class="p-2 pt-1 border">Cod. Item</th>
                        <th class="p-2 pt-1 border">Aluno</th>
                        <th class="p-2 pt-1 border">Cod. de Pessoa</th>
                        <th class="p-2 pt-1 border">Data de Empréstimo</th>
                        <th class="p-2 pt-1">Data de Devolução</th>
                    </tr>
                </thead>
                <tbody class="text-center">
                    <tr v-for="history in paginatedData" :key="history.id" class="linhaTabela">
                        <td class="p-1 border">{{ history.itemName }}</td>
                        <td class="p-1 border">{{ history.itemCode }}</td>
                        <td class="p-1 border">{{ history.studentName }}</td>
                        <td class="p-1 border">{{ history.studentId }}</td>
                        <td class="p-1 px-4 border">{{ new Date(history.dateLend).toLocaleDateString() }} {{ new Date(history.dateLend).toLocaleTimeString() }}</td>
                        <td class="p-1 px-4 border">{{ history.dateReturn ? new Date(history.dateReturn).toLocaleDateString() + ' ' + new Date(history.dateReturn).toLocaleTimeString() : 'Não devolvido' }}</td>
                    </tr>
                </tbody>
            </table>

            <!-- Controles de Paginação -->
            <div class="mt-4 flex justify-center items-center">
                <button @click="prevPage" :disabled="currentPage === 1" class="bg-gray-500 text-black px-4 py-2 rounded ml-2">
                    Anterior
                </button>
                <span class="mx-4">Página {{ currentPage }} de {{ totalPages }}</span>
                <button @click="nextPage" :disabled="currentPage === totalPages" class="bg-blue-500 text-black px-4 py-2 rounded ml-2">
                    Próxima
                </button>
            </div>
        </div>
    </div>
</template>

<script>
import api from '@/services/api';

export default {
    name: 'Historico',
    data() {
        return {
            historico: [],
            loading: true,
            error: false,
            filterNameOrCode: '',
            filterDateFrom: '',
            filterDateTo: '',
            historicoFiltrado: [],
            currentPage: 1,
            itemsPerPage: 20,
        };
    },
    computed: {
        totalPages() {
            return Math.ceil(this.historicoFiltrado.length / this.itemsPerPage);
        },
        paginatedData() {
            const start = (this.currentPage - 1) * this.itemsPerPage;
            const end = start + this.itemsPerPage;
            return this.historicoFiltrado.slice(start, end);
        },
    },
    created() {
        this.getHistorico();
    },
    methods: {
        getHistorico() {
            api.get('LendingManager/History')
                .then(response => {
                    this.historico = response.data;
                    this.historicoFiltrado = this.historico; 
                })
                .catch(() => {
                    this.error = true;
                })
                .finally(() => {
                    this.loading = false;
                });
        },
        applyFilters() {
            this.historicoFiltrado = this.historico.filter((history) => {
                const matchesNameOrCode = this.filterNameOrCode
                    ? history.studentName.toLowerCase().includes(this.filterNameOrCode.toLowerCase()) || history.studentId.toLowerCase().includes(this.filterNameOrCode.toLowerCase())
                    : true;
                
                const matchesDateFrom = this.filterDateFrom
                    ? new Date(history.dateLend) >= new Date(this.filterDateFrom)
                    : true;
                
                const matchesDateTo = this.filterDateTo
                    ? new Date(history.dateLend) <= new Date(this.filterDateTo)
                    : true;

                return matchesNameOrCode && matchesDateFrom && matchesDateTo;
            });
            this.currentPage = 1; 
        },
        clearFilters() {
            this.filterNameOrCode = '';
            this.filterDateFrom = '';
            this.filterDateTo = '';
            this.historicoFiltrado = this.historico; 
            this.currentPage = 1; 
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
            }
        },
        prevPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
            }
        },
    },
};
</script>

<style scoped>
.linhaTabela:hover {
    background-color: #f4f4f4;
}
</style>
