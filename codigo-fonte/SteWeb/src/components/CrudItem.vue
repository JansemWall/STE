<template>
  <div>
    <div v-if="loading" class="flex justify-center items-center">
      <span>Carregando...</span>
    </div>

    <h1>Lista de Itens</h1>


    <div class="create-item">
      <button @click="showCreateInput = !showCreateInput" class="create-button">
        {{ showCreateInput ? 'Cancelar' : 'Adicionar Item' }}
      </button>
  
      <div v-if="showCreateInput" class="create-input">
        <input v-model="newItemName" placeholder="Nome do novo item" />
        <input v-model="newItemCode" placeholder="Código do novo item" />
        <select v-model="newItemCategory" class="category-select">
          <option v-for="category in categories" :key="category.id" :value="category.id">
            {{ category.name }}
          </option>
        </select>
        <button @click="createItem" class="save-button">Salvar</button>
      </div>
    </div>


    <transition-group name="list" tag="ul" class="item-list">
      <li v-for="item in items" :key="item.id">
        <div v-if="item.isEditing">
          <input v-model="item.name" type="text" placeholder="Nome" />
          <input v-model="item.code" type="text" placeholder="Código" />
          <select v-model="item.categoryId" class="category-select">
            <option v-for="category in categories" :key="category.id" :value="category.id">
              {{ category.name }}
            </option>
          </select>
          <button @click="saveItem(item)" class="save-button">Salvar</button>
          <button @click="cancelEdit(item)" class="cancel-button">Cancelar</button>
        </div>
        <div v-else>
          {{ item.name || 'Item sem Nome' }} - Código: {{ item.code }} - Categoria: {{ getCategoryName(item.categoryId) }}
          <button @click="editItem(item)" class="edit-button">Editar</button>
          <button @click="deleteItem(item.id)" class="delete-button">Deletar</button>
        </div>
      </li>
    </transition-group>

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
      categories: [],
      newItemName: '',
      newItemCode: '',
      newItemCategory: '',
      showCreateInput: false,
      error: false,
      loading: true,
    };
  },
  methods: {
    fetchItems() {
      this.loading = true;
      api.get('Item')
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
      api.get('category')
        .then(response => {
          this.categories = response.data;
        })
        .catch(() => {
          this.error = true;
        });
    },
    createItem() {
      if (this.newItemName.trim() && this.newItemCode.trim() && this.newItemCategory) {
        const newItem = {
          name: this.newItemName,
          code: this.newItemCode,
          categoryId: this.newItemCategory,
        };
        api.post('item', newItem)
          .then(response => {
            this.items.push({
              id: response.data.id,
              name: response.data.name,
              code: response.data.code,
              categoryId: response.data.categoryId,
              isEditing: false,
            });
            this.newItemName = '';
            this.newItemCode = '';
            this.newItemCategory = '';
            this.showCreateInput = false;
          })
          .catch(() => {
            alert('Erro ao criar o item');
          });
      } else {
        alert('Todos os campos são obrigatórios');
      }
    },
    editItem(item) {
      item.isEditing = true;
    },
    saveItem(item) {
      const updatedItem = {
        name: item.name,
        code: item.code,
        categoryId: item.categoryId,
      };
      api.put(`item/${item.id}`, updatedItem)
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
        api.delete(`item/${itemId}`)
          .then(() => {
            this.items = this.items.filter(item => item.id !== itemId);
          })
          .catch(() => {
            alert('Erro ao deletar o item');
          });
      }
    },
    getCategoryName(categoryId) {
      const category = this.categories.find(cat => cat.id === categoryId);
      return category ? category.name : 'Categoria não encontrada';
    },
  },
  mounted() {
    this.fetchItems();
    this.fetchCategories();
  },
};
</script>

<style scoped>

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
  transition: all 0.4s ease;
}

/* Transições de entrada e saída */
.list-enter-active, .list-leave-active {
  transition: all 0.5s ease;
}

.list-enter {
  opacity: 0;
  transform: scale(0.9);
}

.list-leave-to {
  opacity: 0;
  transform: scale(0.9);
}

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

.create-input input, .category-select {
  padding: 5px;
  border-radius: 5px;
  border: 1px solid #ccc;
  margin-right: 10px;
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

.error-message {
  color: red;
  text-align: center;
}
</style>
