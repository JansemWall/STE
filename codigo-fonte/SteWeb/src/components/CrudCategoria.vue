<template>
  <div>
    <div v-if="loading" class="flex justify-center items-center">
            <span>Carregando...</span>
        </div>
    <h1>Lista de Categorias</h1>

    <!-- Lista de Categorias -->
    <ul class="category-list">
      <li v-for="category in categories" :key="category.id">
        {{ category.name || 'Categoria sem Nome' }}
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
      error: false, // Variável para controle de erro
    };
  },
  methods: {
    fetchCategories() {
      api.get('Category/GetAll') // Faz a requisição para a API
        .then(response => {
          this.categories = response.data; // Armazena os dados recebidos na variável categories
        })
        .catch(() => {
          this.error = true; // Define o erro como verdadeiro se a requisição falhar
        });
    },
  },
  mounted() {
    this.fetchCategories(); // Chama a função de buscar categorias ao montar o componente
  },
};
</script>

<style scoped>
/* Estilos para a lista de categorias */
h1 {
  text-align: center;
  color: #1d5773;
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
}

/* Estilo para a mensagem de erro */
.error-message {
  color: red;
  text-align: center;
}
</style>
