# Planos de Testes de Software

# Plano de Teste Unitário

## O que é um Teste Unitário?

O teste unitário é uma prática fundamental no desenvolvimento de software, cujo objetivo é garantir a correção das menores unidades de um sistema, como funções, métodos ou classes, de forma isolada. Cada teste unitário verifica se uma unidade específica de código se comporta conforme esperado, validando seus resultados a partir de diferentes entradas e condições.

Esse tipo de teste é automatizado, garantindo uma maior cobertura e possibilitando a detecção de erros logo nas primeiras fases do ciclo de desenvolvimento. Ao testar pequenas partes do código de maneira independente, o teste unitário ajuda a:
- **Prevenir regressões**: Garantindo que alterações futuras no código não quebrem funcionalidades já existentes.
- **Melhorar a qualidade do software**: Detectando problemas mais cedo e facilitando a manutenção.
- **Facilitar refatorações**: Proporcionando confiança para modificar o código sem comprometer funcionalidades já implementadas.
  
A seguir, apresentamos um **Plano de Teste Unitário** para as funcionalidades de três modelos de sistema: **Category**, **Item**, e **ItemLending**.

## 1. Category

### 1.1 Criar Categoria (POST)

1. **Teste de criação com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se a categoria é criada corretamente com dados válidos. | Criar categoria com dados válidos. |  | 

2. **Teste de falha com dados inválidos**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita criação de categoria com dados inválidos. | Criar categoria com nome vazio. |  |

3. **Teste de duplicação**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se o sistema impede a criação de categorias duplicadas. | Criar categoria com nome já existente. |  |

### 1.2 Editar Categoria (PUT)

4. **Teste de edição com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se os dados da categoria são atualizados corretamente. | Editar categoria com nome válido. |  |

5. **Teste de falha com ID inexistente**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita a edição de categoria inexistente. | Tentar editar categoria com ID inválido. |  |

6. **Teste de edição com dados inválidos**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita dados inválidos na edição. | Editar categoria com nome vazio. |  |

### 1.3 Deletar Categoria (DELETE)

7. **Teste de exclusão com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se a categoria é deletada corretamente. | Deletar categoria existente. |  |

8. **Teste de falha com ID inexistente**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita exclusão de categoria inexistente. | Tentar deletar categoria com ID inválido. |  |

### 1.4 Listar Categorias (GET)

9. **Teste de listagem de categorias existentes**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se todas as categorias são listadas corretamente. | Listar categorias existentes. |  |

---

## 2. Item

### 2.1 Criar Item (POST)

10. **Teste de criação com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se o item é criado corretamente com dados válidos. | Criar item com dados válidos. |  |

11. **Teste de falha com dados inválidos**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita criação de item com dados inválidos. | Criar item com nome vazio ou categoria inexistente. |  |

### 2.2 Editar Item (PUT)

12. **Teste de edição com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se os dados do item são atualizados corretamente. | Editar item com dados válidos. |  |

13. **Teste de falha com ID inexistente**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita edição de item inexistente. | Tentar editar item com ID inválido. |  |

### 2.3 Deletar Item (DELETE)

14. **Teste de exclusão com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se o item é deletado corretamente. | Deletar item existente. |  |

### 2.4 Listar Itens (GET)

15. **Teste de listagem de itens existentes**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se todos os itens são listados corretamente. | Listar itens existentes. |  |

---

## 3. ItemLending

### 3.1 Empréstimo (POST)

16. **Teste de empréstimo com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se o item é emprestado corretamente. | Emprestar item disponível. |  |

17. **Teste de falha com item inexistente**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita empréstimo de item inexistente. | Tentar emprestar item com ID inválido. |  |

### 3.2 Devolução (POST)

18. **Teste de devolução com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se o item é devolvido corretamente. | Devolver item emprestado. |  |

19. **Teste de falha com item não emprestado**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Garantir que o sistema rejeita devolução de item que não foi emprestado. | Tentar devolver item não emprestado. |  |

### 3.3 Histórico (GET)

20. **Teste de histórico com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado |  
   | --- | --- | --- | --- | --- |  
   | | | Verificar se o histórico de empréstimos e devoluções é exibido corretamente. | Listar histórico de empréstimos e devoluções. |  |

# Registro de Testes de Software

# Registro de Teste Unitário
 
## 1. Category

### 1.1 Criar Categoria (POST)

1. **Teste de criação com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |  
   | ![image](https://github.com/user-attachments/assets/a9ab7dcb-f0dd-4eed-a5ef-bcc276aa1593) | 29/09/2024 | Verificar se a categoria é criada corretamente com dados válidos. | Criar categoria com dados válidos. | A Categoria foi criada corretamente. | Positivo |
   
2. **Teste de falha com dados inválidos**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |   
   |![image](https://github.com/user-attachments/assets/404d277a-6417-4f5f-97cd-27a8bb86ef28) |29/09/2024 | Garantir que o sistema rejeita criação de categoria com dados inválidos. | Criar categoria com nome vazio. |A categoria foi criada com nome em branco, esse inconsistencia deve ser tratada dentro do sistema. |Negativo |

3. **Teste de duplicação**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |    
   |![image](https://github.com/user-attachments/assets/34cec53b-83e4-47ef-b006-95ef4e5eb63c) |29/09/2024 | Verificar se o sistema impede a criação de categorias duplicadas. | Criar categoria com nome já existente. |Ainda não há nenhum impedimento para criação de categorias com o mesmo nome. |Negativo |

### 1.2 Editar Categoria (PUT)

4. **Teste de edição com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |   
   |![image](https://github.com/user-attachments/assets/45141def-c15d-4b91-8cd6-ef4fa60c0e43)|29/09/2024 | Verificar se os dados da categoria são atualizados corretamente. | Editar categoria com nome válido. |A Categoria foi editada corretamente|

5. **Teste de falha com ID inexistente**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |   
   |![image](https://github.com/user-attachments/assets/f6a32b0f-2437-4d95-b796-110205a3001d)|29/09/2024 | Garantir que o sistema rejeita a edição de categoria inexistente. | Tentar editar categoria com ID inválido. |Não foi possivel editar categoria com ID inválido |Positivo |

6. **Teste de edição com dados inválidos**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |  
   |![image](https://github.com/user-attachments/assets/b2732ac1-a573-42ec-89f2-4970c12d3a6f)|29/09/2024 | Garantir que o sistema rejeita dados inválidos na edição. | Editar categoria com nome vazio. |Foi possivel editar a categoria e deixa-la com nome vazio |Negativo |

### 1.3 Deletar Categoria (DELETE)

7. **Teste de exclusão com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |    
   |![image](https://github.com/user-attachments/assets/618bdfc1-606e-4116-a8d0-9f09d161e5b6) |29/09/2024 | Verificar se a categoria é deletada corretamente. | Deletar categoria existente. |Foi possivel detelar categoria existente. |Positivo |

### 1.4 Listar Categorias (GET)

8. **Teste de listagem de categorias existentes**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |
   | ![image](https://github.com/user-attachments/assets/f551f6eb-7b3d-4e21-9d81-aa6e79794392) | 29/09/2024 | Verificar se todas as categorias são listadas corretamente. | Listar categorias existentes. | Foram apresentadas todas as categorias existentes | Positivo |

---

## 2. Item

### 2.1 Criar Item (POST)

9. **Teste de criação com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |    
   |![image](https://github.com/user-attachments/assets/c641bc7e-d3c7-4467-a791-4dd6f8ba40b6) |29/09/2024 | Verificar se o item é criado corretamente com dados válidos. | Criar item com dados válidos. |Item criado corretamente |Positivo |

10. **Teste de falha com dados inválidos**  
  | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
  | --- | --- | --- | --- | --- | --- |
  |![image](https://github.com/user-attachments/assets/bec088c9-729f-4959-a954-2470d0d824c5) |29/09/2024 | Garantir que o sistema rejeita criação de item com dados inválidos. | Criar item com nome vazio ou categoria inexistente. |O item foi criado com categoria inexistente |Negativo |

### 2.2 Editar Item (PUT)

11. **Teste de edição com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |    
   |![image](https://github.com/user-attachments/assets/85036d06-88a0-4a55-82c0-2d6e6b70a3ae) |29/09/2024 | Verificar se os dados do item são atualizados corretamente. | Editar item com dados válidos. |Os dados foram editados corretamente. |Positivo |

12. **Teste de falha com ID inexistente**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |    
   |![image](https://github.com/user-attachments/assets/d12aa6b0-6c75-426e-b6e4-561227bd82ed) |29/09/2024 | Garantir que o sistema rejeita edição de item inexistente. | Tentar editar item com ID inválido. |Não foi possivel editar item com ID inexistente. |Positivo |

### 2.3 Deletar Item (DELETE)

13. **Teste de exclusão com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |    
   |![image](https://github.com/user-attachments/assets/52c05485-4511-4cf0-b7b2-e24f8255a6c3) |29/09/2024 | Verificar se o item é deletado corretamente. | Deletar item existente. |Foi possivel deletar iten existente. |Positivo |

### 2.4 Listar Itens (GET)

14. **Teste de listagem de itens existentes**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |    
   |![image](https://github.com/user-attachments/assets/be96ae29-324e-4981-bb09-5bc470fbd2e8) |29/09/2024 | Verificar se todos os itens são listados corretamente. | Listar itens existentes. |Os itens existentes foram listados corretamente. |Positivo |

---

## 3. ItemLending

### 3.1 Empréstimo (POST)

15. **Teste de empréstimo com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |    
   |![image](https://github.com/user-attachments/assets/0edae4d2-6671-4ccb-ba06-cca0dc8e0130) |29/09/2024 | Verificar se o item é emprestado corretamente. | Emprestar item disponível. |Foi possivel efetuar o empréstimo com sucesso.  |Positivo |

16. **Teste de falha com item inexistente**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |    
   |![image](https://github.com/user-attachments/assets/a9bd6153-41ef-4058-b759-d1cd59615698) |29/09/2024 | Garantir que o sistema rejeita empréstimo de item inexistente. | Tentar emprestar item com ID inválido. |Não houve sucesso ao tentar emprestar um item com ID inexistente.  |Positivo |

### 3.2 Devolução (POST)

17. **Teste de devolução com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |    
   | | | Verificar se o item é devolvido corretamente. | Devolver item emprestado. | | |

18. **Teste de falha com item não emprestado**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |    
   |![image](https://github.com/user-attachments/assets/1c938017-4831-4ce5-b95f-27d9c6a3359f) |29/09/2024 | Garantir que o sistema rejeita devolução de item que não foi emprestado. | Tentar devolver item não emprestado. |Não foi possivel registrar a devolução um item que não estava emprestado. |Positivo |

### 3.3 Histórico (GET)

19. **Teste de histórico com sucesso**  
   | Caso de Teste | Data do teste | Objetivo | Descrição do teste | Descrição do resultado | Resultado do Teste |
   | --- | --- | --- | --- | --- | --- |    
   |![image](https://github.com/user-attachments/assets/fda32da2-ee4e-4202-bec5-51a6fcab65d1) |29/09/2024 | Verificar se o histórico de empréstimos e devoluções é exibido corretamente. | Listar histórico de empréstimos e devoluções. |O histórico dos itens emprestados e devolvidos é apresentado corretamente.  |Positivo |

