<template>
    <div class="card-container">

    <RouterLink to="/categoria">
    <div class="card">
      <img src="https://via.placeholder.com/80" alt="Imagem 1" class="card-image">
      <h3>Categorias</h3>
    </div>
    </RouterLink>
    <RouterLink to="/devolver">
    <div class="card">
      <img src="https://via.placeholder.com/80" alt="Imagem 2" class="card-image">
      <h3>Items</h3>
    </div>
    </RouterLink>
    <RouterLink to="/historico">
    <div class="card">
      <img src="https://via.placeholder.com/80" alt="Imagem 3" class="card-image">
      <h3>Usuarios</h3>
    </div>
    </RouterLink>

  </div>

  </template>
  
  <style scoped>
 
 .card-container {
  display: flex; /* Usando flexbox */
  justify-content: center; /* Centraliza os cards horizontalmente */
  gap: 20px; /* Espaçamento entre os cards */
  padding: 20px; /* Espaçamento interno da container */
}

.card {
  background-color: #f9f9f9; /* Cor de fundo do card */
  border: 1px solid #ddd; /* Borda do card */
  border-radius: 10px; /* Bordas arredondadas */
  padding: 20px; /* Espaçamento interno do card */
  text-align: center; /* Centraliza o texto dentro do card */
  height: 200px;
  width: 250px; /* Largura fixa do card */
}

.card-image {
  width: 80px; /* Largura da imagem */
  height: 80px; /* Altura da imagem */
  border-radius: 50%; /* Torna a imagem circular */
  margin-bottom: 10px; /* Espaçamento abaixo da imagem */
  align-self: center;
}
  </style>