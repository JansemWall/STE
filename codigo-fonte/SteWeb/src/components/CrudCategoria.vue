<template>
  <div>
    <div v-if="loading" class="flex justify-center items-center">
      <span>Carregando...</span>
    </div>

    <h1>Lista de Categorias</h1>

    <!-- Botão para adicionar nova categoria -->
    <div class="create-category">
      <button @click="showCreateInput = !showCreateInput" class="create-button">
        {{ showCreateInput ? 'Cancelar' : 'Adicionar Categoria' }}
      </button>
      <!-- Input para adicionar categoria -->
      <div v-if="showCreateInput" class="create-input">
        <input v-model="newCategoryName" placeholder="Nome da nova categoria" />
        <button @click="createCategory" class="save-button">Salvar</button>
      </div>
    </div>

    <!-- Lista de Categorias -->
    <ul class="category-list">
      <li v-for="category in categories" :key="category.id">
        <div v-if="category.isEditing">
          <input v-model="category.name" type="text" />
          <button @click="saveCategory(category)" class="save-button">Salvar</button>
          <button @click="cancelEdit(category)" class="cancel-button">Cancelar</button>
        </div>
        <div v-else>
          {{ category.name || 'Categoria sem Nome' }}
          <button @click="editCategory(category)" class="edit-button">Editar</button>
          <button @click="deleteCategory(category.id)" class="delete-button">Deletar</button>
        </div>
      </li>
    </ul>

    <!-- Mensagem de erro -->
    <div v-if="error" class="error-message">
      Ocorreu um erro ao buscar as categorias. Tente novamente mais tarde.
    </div>
  </div>
</template>

<script>
import api from '@/services/api';

export default {
  data() {
    return {
      categories: [],
      newCategoryName: '', // Nome da nova categoria
      showCreateInput: false, // Controla exibição do input de criação
      error: false,
      loading: true,
    };
  },
  methods: {
    fetchCategories() {
      this.loading = true;
      api.get('Category/GetAll')
        .then(response => {
          this.categories = response.data.map(category => ({
            ...category,
            isEditing: false,
          }));
          this.loading = false;
        })
        .catch(() => {
          this.error = true;
          this.loading = false;
        });
    },
    createCategory() {
      if (this.newCategoryName.trim()) {
        api.post('Category/Create', { name: this.newCategoryName }) // Chamada para a API de criação
          .then(response => {
            this.categories.push({
              id: response.data.id,
              name: response.data.name,
              isEditing: false,
            });
            this.newCategoryName = ''; // Limpa o campo de input
            this.showCreateInput = false; // Fecha o input de criação
          })
          .catch(() => {
            alert('Erro ao criar a categoria');
          });
      } else {
        alert('O nome da categoria não pode estar vazio');
      }
    },
    editCategory(category) {
      category.isEditing = true;
    },
    saveCategory(category) {
      api.put(`Category/Update/${category.id}`, { name: category.name })
        .then(() => {
          category.isEditing = false;
        })
        .catch(() => {
          alert('Erro ao salvar a categoria');
        });
    },
    cancelEdit(category) {
      this.fetchCategories();
    },
    deleteCategory(categoryId) {
      if (confirm('Tem certeza que deseja deletar esta categoria?')) {
        api.delete(`Category/Delete/${categoryId}`)
          .then(() => {
            this.categories = this.categories.filter(category => category.id !== categoryId);
          })
          .catch(() => {
            alert('Erro ao deletar a categoria');
          });
      }
    },
  },
  mounted() {
    this.fetchCategories();
  },
};
</script>

<style scoped>
/* Estilos para a lista de categorias */
h1 {
  text-align: center;
  color: #1d5773;
}

.create-category {
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

.category-list {
  list-style-type: none;
  padding: 0;
  margin: 20px 0;
}

.category-list li {
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
