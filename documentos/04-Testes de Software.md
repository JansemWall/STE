# Planos de Testes de Software

# Plano de Teste Unitário

## O que é um Teste Unitário?

O teste unitário é uma prática fundamental no desenvolvimento de software, cujo objetivo é garantir a correção das menores unidades de um sistema, como funções, métodos ou classes, de forma isolada. Cada teste unitário verifica se uma unidade específica de código se comporta conforme esperado, validando seus resultados a partir de diferentes entradas e condições.

Esse tipo de teste é automatizado, garantindo uma maior cobertura e possibilitando a detecção de erros logo nas primeiras fases do ciclo de desenvolvimento. Ao testar pequenas partes do código de maneira independente, o teste unitário ajuda a:
- **Prevenir regressões**: Garantindo que alterações futuras no código não quebrem funcionalidades já existentes.
- **Melhorar a qualidade do software**: Detectando problemas mais cedo e facilitando a manutenção.
- **Facilitar refatorações**: Proporcionando confiança para modificar o código sem comprometer funcionalidades já implementadas.
  
A seguir, apresentamos um **Plano de Teste Unitário** para as funcionalidades de três modelos de sistema: **Category**, **Item**, e **ItemLending**.

---

## 1. Category

### 1.1 Criar Categoria (POST)

1. **Teste de criação com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se a categoria é criada corretamente com dados válidos. | Criar categoria com dados válidos. | A categoria deve ser criada com sucesso. |

2. **Teste de falha com dados inválidos**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita criação de categoria com dados inválidos. | Criar categoria com nome vazio. | O sistema deve retornar um erro. |

3. **Teste de duplicação**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se o sistema impede a criação de categorias duplicadas. | Criar categoria com nome já existente. | O sistema deve rejeitar categorias duplicadas. |

### 1.2 Editar Categoria (PUT)

4. **Teste de edição com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se os dados da categoria são atualizados corretamente. | Editar categoria com nome válido. | A categoria deve ser atualizada com sucesso. |

5. **Teste de falha com ID inexistente**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita a edição de categoria inexistente. | Tentar editar categoria com ID inválido. | O sistema deve retornar um erro. |

6. **Teste de edição com dados inválidos**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita dados inválidos na edição. | Editar categoria com nome vazio. | O sistema deve retornar um erro. |

### 1.3 Deletar Categoria (DELETE)

7. **Teste de exclusão com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se a categoria é deletada corretamente. | Deletar categoria existente. | A categoria deve ser deletada com sucesso. |

8. **Teste de falha com ID inexistente**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita exclusão de categoria inexistente. | Tentar deletar categoria com ID inválido. | O sistema deve retornar um erro. |

### 1.4 Listar Categorias (GET)

9. **Teste de listagem de categorias existentes**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se todas as categorias são listadas corretamente. | Listar categorias existentes. | O sistema deve exibir todas as categorias. |

10. **Teste de listagem quando não há categorias**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar o retorno quando não há categorias cadastradas. | Listar categorias em sistema vazio. | O sistema deve retornar lista vazia ou mensagem adequada. |

---

## 2. Item

### 2.1 Criar Item (POST)

11. **Teste de criação com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se o item é criado corretamente com dados válidos. | Criar item com dados válidos. | O item deve ser criado com sucesso. |

12. **Teste de falha com dados inválidos**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita criação de item com dados inválidos. | Criar item com nome vazio ou categoria inexistente. | O sistema deve retornar um erro. |

### 2.2 Editar Item (PUT)

13. **Teste de edição com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se os dados do item são atualizados corretamente. | Editar item com dados válidos. | O item deve ser atualizado com sucesso. |

14. **Teste de falha com ID inexistente**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita edição de item inexistente. | Tentar editar item com ID inválido. | O sistema deve retornar um erro. |

### 2.3 Deletar Item (DELETE)

15. **Teste de exclusão com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se o item é deletado corretamente. | Deletar item existente. | O item deve ser deletado com sucesso. |

### 2.4 Listar Itens (GET)

16. **Teste de listagem de itens existentes**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se todos os itens são listados corretamente. | Listar itens existentes. | O sistema deve exibir todos os itens. |

---

## 3. ItemLending

### 3.1 Empréstimo (POST)

17. **Teste de empréstimo com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se o item é emprestado corretamente. | Emprestar item disponível. | O item deve ser marcado como emprestado. |

18. **Teste de falha com item inexistente**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita empréstimo de item inexistente. | Tentar emprestar item com ID inválido. | O sistema deve retornar um erro. |

### 3.2 Devolução (POST)

19. **Teste de devolução com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se o item é devolvido corretamente. | Devolver item emprestado. | O item deve ser marcado como devolvido. |

20. **Teste de falha com item não emprestado**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita devolução de item que não foi emprestado. | Tentar devolver item não emprestado. | O sistema deve retornar um erro. |

### 3.3 Histórico (GET)

21. **Teste de histórico com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se o histórico de empréstimos e devoluções é exibido corretamente. | Listar histórico de empréstimos e devoluções. | O sistema deve exibir todo o histórico corretamente. |

22. **Teste de histórico vazio**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar o retorno quando não há histórico de empréstimos. | Listar histórico em sistema vazio. | O sistema deve retornar lista vazia ou mensagem adequada. |

 
# Evidências de Testes de Software

Apresente imagens e/ou vídeos que comprovam que um determinado teste foi executado, e o resultado esperado foi obtido. Normalmente são screenshots de telas, ou vídeos do software em funcionamento.
