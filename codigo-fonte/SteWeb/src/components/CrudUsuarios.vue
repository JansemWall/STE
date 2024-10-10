<template>
    <div>
      <div v-if="loading" class="flex justify-center items-center">
        <span>Carregando...</span>
      </div>
  
      <h1>Lista de Usuários</h1>
  
      <!-- Botão para adicionar novo usuário -->
      <div class="create-user">
        <button @click="showCreateInput = !showCreateInput" class="create-button">
          {{ showCreateInput ? 'Cancelar' : 'Adicionar Usuário' }}
        </button>
        <!-- Input para adicionar usuário -->
        <div v-if="showCreateInput" class="create-input">
          <input v-model="newUserName" placeholder="Nome do novo usuário" />
          <input v-model="newUserPassword" placeholder="Senha do usuário" type="password" />
          <button @click="createUser" class="save-button">Salvar</button>
        </div>
      </div>
  
      <!-- Lista de Usuários -->
      <ul class="user-list">
        <li v-for="user in users" :key="user.id">
          <div v-if="user.isEditing">
            <input v-model="user.name" type="text" placeholder="Nome" />
            <input v-model="user.password" type="password" placeholder="Senha" />
            <button @click="saveUser(user)" class="save-button">Salvar</button>
            <button @click="cancelEdit(user)" class="cancel-button">Cancelar</button>
          </div>
          <div v-else>
            {{ user.name || 'Usuário sem Nome' }}
            <button @click="editUser(user)" class="edit-button">Editar</button>
            <button @click="deleteUser(user.id)" class="delete-button">Deletar</button>
          </div>
        </li>
      </ul>
  
      <!-- Mensagem de erro -->
      <div v-if="error" class="error-message">
        Ocorreu um erro ao buscar os usuários. Tente novamente mais tarde.
      </div>
    </div>
  </template>
  
  <script>
  import api from '@/services/api';
  import { toast } from 'vue3-toastify';
  
  export default {
    data() {
      return {
        users: [],
        newUserName: '',
        newUserPassword: '',
        showCreateInput: false,
        error: false,
        loading: true,
      };
    },
    methods: {
      fetchUsers() {
        this.loading = true;
        api.get('User/GetAllUsers') 
          .then(response => {
            this.users = response.data.map(user => ({
              ...user,
              isEditing: false,
            }));
            this.loading = false;
          })
          .catch(() => {
            this.error = true;
            this.loading = false;
          });
      },
      createUser() {
        if (this.newUserName.trim() && this.newUserPassword.trim()) {
          const newUser = {
            name: this.newUserName,
            password: this.newUserPassword,
          };
          api.post('User/Create', newUser) 
            .then(response => {
              this.users.push({
                id: response.data.id,
                name: response.data.name,
                password: '', 
                isEditing: false,
              });
              toast.success('Usuario criado com sucesso.')
              
              this.newUserName = '';
              this.newUserPassword = '';
              this.showCreateInput = false;
            })
            .catch(() => {
              toast.error('Número insuficiente de caracteres para criar o usuário.')
            });
        } else {
          toast.info('Nome e senha são obrigatórios')
        }
      },
      editUser(user) {
        user.isEditing = true;
      },
      saveUser(user) {
        api.put(`User/Edit/${user.id}`, { name: user.name, password: user.password }) 
          .then(() => {
            user.isEditing = false;
          })
          .catch(() => {
            toast.error('Erro ao salvar usuario. A senha deve ter no minimo 8 caracteres.')
          });
      },
      cancelEdit(user) {
        this.fetchUsers(); 
      },
      deleteUser(userId) {
        if (confirm('Tem certeza que deseja deletar este usuário?')) {
          api.delete(`User/Delete/${userId}`) 
            .then(() => {
              this.users = this.users.filter(user => user.id !== userId);
            })
            .catch(() => {
                toast.error('Erro ao deletar usuario! Contate o administrador.')
            });
        }
      },
    },
    mounted() {
      this.fetchUsers(); 
    },
  };
  </script>
  
  <style scoped>
  /* Estilos para a lista de usuários */
  h1 {
    text-align: center;
    color: #1d5773;
  }
  
  .create-user {
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
  
  .user-list {
    list-style-type: none;
    padding: 0;
    margin: 20px 0;
  }
  
  .user-list li {
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
  