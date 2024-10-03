<template>
  <div>
    <div v-if="loading" class="flex justify-center items-center">
      <span>Carregando...</span>
    </div>

    <h1>Lista de Itens</h1>

    <!-- Botão para adicionar novo item -->
    <div class="create-item">
      <button @click="showCreateInput = !showCreateInput" class="create-button">
        {{ showCreateInput ? 'Cancelar' : 'Adicionar Item' }}
      </button>
      <!-- Input para adicionar item com seleção de categoria -->
      <div v-if="showCreateInput" class="create-input">
        <input v-model="newItemName" placeholder="Nome do novo item" />
        <input v-model="newItemCode" placeholder="Código do item" />
        <select v-model="selectedCategoryId">
          <option disabled value="">Selecione uma categoria</option>
          <option v-for="category in categories" :key="category.id" :value="category.id">
            {{ category.name }}
          </option>
        </select>
        <button @click="createItem" class="save-button">Salvar</button>
      </div>
    </div>

    <!-- Lista de Itens -->
    <ul class="item-list">
      <li v-for="item in items" :key="item.id">
        <div v-if="item.isEditing">
          <input v-model="item.name" type="text" />
          <button @click="saveItem(item)" class="save-button">Salvar</button>
          <button @click="cancelEdit(item)" class="cancel-button">Cancelar</button>
        </div>
        <div v-else>
          {{ item.name || 'Item sem Nome' }} ({{ item.categoryName }})
          <button @click="editItem(item)" class="edit-button">Editar</button>
          <button @click="deleteItem(item.id)" class="delete-button">Deletar</button>
        </div>
      </li>
    </ul>

    <!-- Mensagem de erro -->
    <div v-if="error" class="error-message">
      Ocorreu um erro ao buscar os itens. Tente novamente mais tarde.
    </div>
  </div>
</template>

<script>
import api from '@/services/api';

export default {
  data() {
    return {
      items: [],
      categories: [], // Armazena as categorias
      newItemName: '',
      newItemCode: '',
      selectedCategoryId: '', // Armazena o ID da categoria selecionada
      showCreateInput: false,
      error: false,
      loading: true,
    };
  },
  methods: {
    fetchItems() {
      this.loading = true;
      api.get('Item/GetAll')
        .then(response => {
          this.items = response.data.map(item => ({
            ...item,
            isEditing: false,
          }));
          this.loading = false;
        })
        .catch(() => {
          this.error = true;
          this.loading = false;
        });
    },
    fetchCategories() {
      api.get('Category/GetAll')
        .then(response => {
          this.categories = response.data;
        })
        .catch(() => {
          alert('Erro ao carregar categorias');
        });
    },
    createItem() {
      if (this.newItemName.trim() && this.selectedCategoryId) {
        const newItem = {
          name: this.newItemName,
          code: this.newItemCode,
          categoryId: this.selectedCategoryId,
        };
        api.post('Item/Create', newItem) // Chamada para criar o item com a categoria selecionada
          .then(response => {
            this.items.push({
              id: response.data.id,
              name: response.data.name,
              categoryId: response.data.categoryId,
              categoryName: this.getCategoryNameById(response.data.categoryId),
              isEditing: false,
            });
            this.newItemName = '';
            this.newItemCode = '';
            this.selectedCategoryId = '';
            this.showCreateInput = false;
          })
          .catch(() => {
            alert('Erro ao criar o item');
          });
      } else {
        alert('O nome do item e a categoria são obrigatórios');
      }
    },
    getCategoryNameById(categoryId) {
      const category = this.categories.find(c => c.id === categoryId);
      return category ? category.name : 'Categoria Desconhecida';
    },
    editItem(item) {
      item.isEditing = true;
    },
    saveItem(item) {
      api.put(`Item/Edit/${item.id}`, { name: item.name })
        .then(() => {
          item.isEditing = false;
        })
        .catch(() => {
          alert('Erro ao salvar o item');
        });
    },
    cancelEdit(item) {
      this.fetchItems();
    },
    deleteItem(itemId) {
      if (confirm('Tem certeza que deseja deletar este item?')) {
        api.delete(`Item/Delete/${itemId}`)
          .then(() => {
            this.items = this.items.filter(item => item.id !== itemId);
          })
          .catch(() => {
            alert('Erro ao deletar o item');
          });
      }
    },
  },
  mounted() {
    this.fetchItems(); // Busca os itens ao carregar o componente
    this.fetchCategories(); // Busca as categorias para a lista de seleção
  },
};
</script>

<style scoped>
/* Estilos para a lista de itens */
h1 {
  text-align: center;
  color: #1d5773;
}

.create-item {
  margin-bottom: 20px;
  text-align: center;
}

.create-button {
  padding: 10px 20px;
  background-color: #008CBA;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

.create-input {
  margin-top: 10px;
  display: flex;
  justify-content: center;
}

.create-input input {
  padding: 5px;
  border-radius: 5px;
  border: 1px solid #ccc;
  margin-right: 10px;
}

.create-input select {
  margin-left: 10px;
  padding: 5px;
  border-radius: 5px;
}

.item-list {
  list-style-type: none;
  padding: 0;
  margin: 20px 0;
}

.item-list li {
  background-color: #f4f4f4;
  margin: 5px 0;
  padding: 10px;
  border-radius: 5px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.edit-button, .delete-button, .save-button, .cancel-button {
  margin-left: 10px;
  padding: 5px 10px;
  border: none;
  border-radius: 3px;
  cursor: pointer;
}

.edit-button {
  background-color: #4CAF50;
  color: white;
}

.delete-button {
  background-color: #F44336;
  color: white;
}

.save-button {
  background-color: #008CBA;
  color: white;
}

.cancel-button {
  background-color: #e7e7e7;
  color: black;
}

/* Estilo para a mensagem de erro */
.error-message {
  color: red;
  text-align: center;
}
</style>
