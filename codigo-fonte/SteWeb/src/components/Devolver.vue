<template>

<div class="flex flex-column">
    <h2 class="text-xl mb-4">Devolução de Itens</h2>
    <div v-if="loading" class="flex justify-center items-center">
        <span>Carregando...</span>
    </div>

    <table v-else class="justify-items-center w-full">

        <div v-if="error" color="red" class="mb-4">Erro ao carregar item para devolução.</div>
        <thead>
            <tr>
                <th class="pb-2 px-4 pt-1">Cod. Item</th>
                <th class="pb-2 px-4 pt-1">Item</th>
                <th class="pb-2 px-4 pt-1">Aluno</th>
                <th class="pb-2 px-4 pt-1">Cod. de Pessoa</th>
                <th class="pb-2 px-4 pt-1">Técnico</th>
                <th class="pb-2 px-4 pt-1">Data de Empréstimo</th>
                <th class="pb-2 px-4 pt-1">Ação</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="item in items" :key="item.id" class="hover:bg-gray-100">

                <td class="py-1 px-4">{{ item.itemCode }}</td>
                <td class="py-1 px-4">{{ item.name }}</td>
                <td class="py-1 px-4">{{ item.studentName }}</td>
                <td class="py-1 px-4">{{ item.studentId }}</td>
                <td class="py-1 px-4">{{ item.userId }}</td>
                <td class="py-1 px-4">{{ new Date(item.dateLend).toLocaleDateString() }}</td>
                <td class="py-1 px-4">
                    <button class="bg-blue-500 text-white px-3 py-1 rounded hover:bg-blue-600"
                        @click="returnItem(item.itemId)">
                        Devolver
                    </button>
                </td>
            </tr>
        </tbody>
    </table>
</div>
</template>

<script>
import api from '@/services/api'
import { toast } from 'vue3-toastify';

export default {
    name: 'Devolucao',
    props: {
        onClose: {
            type: Function,
            required: true,
        },
    },
    data() {
        return {
            items: [],
            loading: true,
            error: false,
            success: false,
        }
    },
    created() {
        this.fetchPendingItems()
    },
    methods: {
        fetchPendingItems() {
            this.loading = true; // Define o loading como verdadeiro ao buscar os itens
            api.get('LendingManager/History')
                .then(response => {
                    this.items = response.data.filter(item => !item.dateReturn);
                })
                .catch(() => {
                    this.error = true;
                })
                .finally(() => {
                    this.loading = false; // Define o loading como falso após a busca
                });
        },
        returnItem(id) {
            this.error = false;
            this.success = false;

            api.post(`LendingManager/Return/${id}`)
                .then(() => {
                    this.success = true;
                    toast.success('Item devolvido com sucesso!');
                    this.fetchPendingItems();
                })
                .catch(() => {
                    this.error = true;
                    toast.error('Falha para devolver o item!');
                });
        },
    }
}

</script>

<style scoped>
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