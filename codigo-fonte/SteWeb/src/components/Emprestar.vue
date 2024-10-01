<template>
    <div>
        <div>
            <div class="mb-4">
                <select v-model="selectItemId" class="w-full p-2 border rounded">
                    <option value="" disabled>Selecione o ID</option>
                    <option v-for="item in items" :key="item.id" :value="item.id">
                        {{ item.code }}
                    </option>
                </select>
            </div>
            <div class="mb-4">
                <span v-if="selectItemId">{{ items.find(item => item.id === selectItemId)?.name }}</span>
            </div>

            <!-- Campos para nome e ID do estudante aparecem apenas quando uma opção válida é selecionada -->
            <div v-if="selectItemId">
                <div class="mb-4">
                    <input v-model="studentName" type="text" placeholder="Nome do Estudante" class="w-full p-2 border rounded" />
                </div>
                <div class="mb-4">
                    <input v-model="studentId" type="text" placeholder="ID do Estudante" class="w-full p-2 border rounded" />
                </div>
                <div>
                    <button @click="lendItem" class="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600">
                        Emprestar
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import api from '@/services/api'
import { toast } from 'vue3-toastify';
    
export default {
    name: 'Emprestar',
    data() {
        return {
            items: [],          // Lista de itens disponíveis
            selectItemId: '',   // ID do item selecionado
            studentName: '',     // Nome do estudante
            studentId: '',       // ID do estudante
            success: false,
            error: false,
        }
    },
    created() {
        this.fetchItems()
    },
    methods: {
        fetchItems() {
            api.get('Item/Getall')
                .then(response => {
                    // Filtra os itens que têm `isLend`, indicando que não estão emprestados
                    this.items = response.data.filter(item => !item.isLend)
                })
                .catch(() => {
                    this.error = true
                })
                .finally(() => {
                    this.loading = false
                })
        },
        lendItem() {
            if (!this.selectItemId || !this.studentName || !this.studentId) {
                return; // Garante que todos os campos estejam preenchidos
            }
            this.error = false;
            this.success = false;

            // Cria o objeto que será enviado
            const requestData = {
                studentName: this.studentName,
                studentId: this.studentId
            };

            // Faz a requisição para emprestar o item selecionado
            api.post(`LendingManager/Lend/${this.selectItemId}`, requestData, {
                headers: {
                    'Content-Type': 'application/json' // Define o cabeçalho Content-Type
                   
                }
                
                
            })
            .then(() => {
                this.success = true;
                toast.success('Item emprestado com sucesso!')
                // Limpa os campos após sucesso
                this.studentName = '';
                this.studentId = '';
                this.selectItemId = '';
                setTimeout(function(){window.location.reload()}, 900)
            })
            .catch(() => {
                this.error = true
                toast.error('Falha ao emprestar item!')
            })
        },
    },
}
</script>

<style scoped>
/* Estilos opcionais para melhorar a aparência */
select {
    width: 100%;
    padding: 8px;
    margin-bottom: 16px;
    border: 1px solid #ccc;
    border-radius: 4px;
}
</style>
