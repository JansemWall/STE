<template>
    <div>
        <div v-if="loading" class="flex justify-center items-center">
            <span>Carregando...</span>
        </div>
        <div v-else>
            <h2 class="text-2xl font-semibold pb-5">Empréstimo</h2>
            <!-- Seleção de Categoria -->
            <div class="card-container mb-4" v-if="!selectedCategoryId">
                <div v-for="category in categories" :key="category.id" class="card"
                    @click="selectCategory(category.id)">
                    <h3>{{ category.name }}</h3>
                </div>
            </div>

            <!-- Seleção de Item -->
            <div class="mb-4" v-if="selectedCategoryId">
                <select v-model="selectItemId" class="w-full p-2 border rounded" :disabled="!selectedCategoryId">
                    <option value="" disabled>Selecione o ID</option>
                    <option class="color:red" v-for="categoria in categories" :key="categoria.id" :value="categoria.id">
                        {{ categoria.code }}
                    </option>
                </select>
            </div>

            <div class="mb-4">
                <span v-if="selectItemId">{{ items.find(item => item.id === selectItemId)?.name }}</span>
            </div>

            <!-- Campos para nome e ID do estudante aparecem apenas quando uma opção válida é selecionada -->
            <div v-if="selectItemId">
                <div class="mb-4">
                    <input v-model="studentName" type="text" placeholder="Nome do Estudante"
                        class="w-full p-2 border rounded" />
                </div>
                <div class="mb-4">
                    <input v-model="studentId" type="text" placeholder="ID do Estudante"
                        class="w-full p-2 border rounded" />
                </div>
                <div>
                    <button @click="lendItem" class="bg-blue-500 px-4 py-2 rounded hover:bg-blue-600">
                        Emprestar
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import api from '@/services/api';
import { toast } from 'vue3-toastify';

export default {
    name: 'Emprestar',
    data() {
        return {
            categories: [],       // Lista de categorias
            items: [],           // Lista de itens disponíveis
            selectedCategoryId: '', // ID da categoria selecionada
            selectItemId: '',    // ID do item selecionado
            studentName: '',     // Nome do estudante
            studentId: '',       // ID do estudante
            success: false,
            error: false,
            loading: true, //abre a página em carregamento
        };
    },
    created() {
        this.fetchCategories(); // Busca as categorias na criação do componente
    },
    watch: {
        selectedCategoryId(newValue) {
            if (newValue) {
                this.fetchItemsByCategory(newValue); // Busca itens quando a categoria muda
            }
        }
    },
    methods: {
        selectCategory(categoryId) {
            this.selectedCategoryId = categoryId; // Atualiza a categoria selecionada
            this.fetchItemsByCategory(categoryId); // Busca itens da categoria selecionada
        },
        fetchCategories() {
            api.get('category')
                .then(response => {
                    // Filtra categorias que têm itens disponíveis para empréstimo
                    this.categories = response.data.filter(category =>
                        category.items.some(item => !item.isLend)
                    );
                })
                .catch(() => {
                    this.error = true;
                })
                .finally(() => {
                    this.loading = false;
                });
        },
        fetchItemsByCategory(categoryId) {
            api.get(`category/${categoryId}`)
                .then(response => {
                    // Filtra os itens que têm `isLend`, indicando que não estão emprestados
                    this.categories = response.data.items.filter(category => !category.isLend);
                })
                .catch(() => {
                    this.error = true;
                })
                .finally(() => {
                    this.loading = false;
                });;
        },
        lendItem() {
            if (!this.selectItemId || !this.studentName || !this.studentId) {
                return;
            }
            this.error = false;
            this.success = false;

            const requestData = {
                studentName: this.studentName,
                studentId: this.studentId
            };

            // Faz a requisição para emprestar o item selecionado
            api.post(`lendingManager/lend/${this.selectItemId}`, requestData, {
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(() => {
                    this.success = true;
                    toast.success('Item emprestado com sucesso!');
                    this.studentName = '';
                    this.studentId = '';
                    this.selectItemId = '';
                    this.fetchItemsByCategory(this.selectedCategoryId);
                })
                .catch(() => {
                    this.error = true;
                    toast.error('Falha ao emprestar item!');
                });
        },
    },
}
</script>


<style scoped>
select {
    width: 100%;
    padding: 8px;
    margin-bottom: 16px;
    border: 1px solid #ccc;
    border-radius: 4px;
}

.card-container {
    display: flex;
    justify-content: center;
    flex-wrap: wrap;
    gap: 20px;
    padding: 20px;
}

.card {
    background-color: #f9f9f9;
    border: 1px solid #ddd;
    color: #000;
    border-radius: 10px;
    padding: 20px;
    text-align: center;
    height: 200px;
    width: 250px; /* Largura fixa do card */
    cursor: pointer;
    transition: background-color 0.3s;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.card:hover {
    background-color: #e0e0e0;
    /* Efeito ao passar o mouse */
}
</style>
