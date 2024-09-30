<template>
  <footer>
    <a href="#">Contato</a> |
    <a href="#">Política de Privacidade</a> |
    <a href="#">Termos e Condições</a>
  </footer>
</template>

<style scoped>
  footer {
    background-color: #f0f0f0; /* Cor de fundo do rodapé */
    padding: 90px; /* Espaçamento interno do rodapé */
    text-align: center; /* Alinhar texto ao centro */
    position: fixed; /* Fixar o rodapé na parte inferior da página */
    bottom: 0;
    left: 0; /* Alinhar à esquerda */
    width: 100%; /* Ocupa toda a largura */
    height: 200px; /* Altura automática para ajuste */
    box-shadow: 0 -2px 5px rgba(0, 0, 0, 0.1); /* Adiciona sombra ao rodapé */
  }

  footer a {
    color: #333; /* Cor do link */
    text-decoration: none; /* Remover sublinhado do link */
    margin: 0 10px; /* Espaçamento entre os links */
  }
</style>