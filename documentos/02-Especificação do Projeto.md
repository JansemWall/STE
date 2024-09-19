# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

A proposta do projeto consiste em desenvolver um sistema de controle de empréstimo de itens. Imagine um cenário em que você precise de um item por um período específico, como uma mesa digitalizadora, uma webcam ou até mesmo um fone de ouvido. Nesse contexto, o pedido do item será realizado presencialmente, onde um funcionário responsável coletará seus dados e registrará tanto o empréstimo quanto suas informações no sistema.

Esse sistema será utilizado exclusivamente para o controle e a segurança dos itens, de modo que apenas funcionários autorizados terão acesso a ele.

## Arquitetura e Tecnologias

A arquitetura do sistema de empréstimo de itens será composta por três camadas principais: a camada de dados, a camada de back-end e a camada de front-end.

Camada de Dados (Banco de Dados NoSQL - MongoDB):
O sistema utilizará o MongoDB como o banco de dados NoSQL. MongoDB é ideal para armazenar os dados de forma flexível e escalável, permitindo o armazenamento de documentos JSON que podem representar os itens emprestados, informações dos usuários, registros de empréstimos, entre outros. Sua capacidade de lidar com grandes volumes de dados e realizar consultas rápidas será essencial para o bom desempenho do sistema.

Camada de Back-End (C#):
O back-end do sistema será desenvolvido em C#, utilizando frameworks como ASP.NET Core. Esta camada será responsável por implementar a lógica de negócios do sistema, incluindo a gestão dos empréstimos, validação dos dados, autenticação e autorização dos funcionários, além de comunicar-se com o banco de dados MongoDB. A API RESTful desenvolvida em C# fornecerá os endpoints necessários para que o front-end interaja com o sistema de forma segura e eficiente.

Camada de Front-End (Django):
A interface do usuário será construída utilizando o Django, um framework web baseado em Python. Embora Django seja tradicionalmente um framework full-stack, aqui ele será utilizado principalmente para criar a interface de usuário e para consumir a API RESTful do back-end. Django facilitará o desenvolvimento de um front-end intuitivo, onde os funcionários poderão realizar e gerenciar os empréstimos de forma eficiente. A camada de apresentação será projetada para ser simples e intuitiva, garantindo que os funcionários possam acessar rapidamente as funcionalidades necessárias.

Integração entre as Camadas:
A comunicação entre o front-end (Django) e o back-end (C#) será feita através de requisições HTTP para os endpoints expostos pela API. O back-end, por sua vez, se comunicará com o MongoDB para realizar operações de leitura e escrita de dados. O fluxo de dados será assegurado por meio de autenticação e autorização, garantindo que apenas funcionários autorizados tenham acesso às funcionalidades do sistema.

Essa arquitetura modular garante escalabilidade, segurança e facilidade de manutenção, permitindo que cada camada seja desenvolvida, testada e escalada de forma independente.

<center><img src="img/diagrama-arquitetura.png" /></center>

## Project Model Canvas

Colocar a imagem do modelo construído apresentando a proposta de solução.

> **STE**:
> [Model Canvas] ([https://app.projectcanvas.online/projects/66d4c049723c4af49d389625](https://app.projectcanvas.online/beta/public-project/ZJyi4UhMoFnIm4ME5rlB9JucBmTNTwfPS8jGVYWvbI=))
> ![image](https://github.com/user-attachments/assets/8d1a24ab-e7bd-4264-b29a-8c76867a6557)


## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto. Para determinar a prioridade de requisitos, aplicar uma técnica de priorização de requisitos e detalhar como a técnica foi aplicada.

### Requisitos Funcionais

| ID     | Descrição do Requisito   | Prioridade |
| ------ | ----------------------------------------- | ---- |
| RF-001 | A aplicação deve permitir o empréstimo e devolução de equipamentos de informática   | ALTA |
| RF-002 | O empréstimo e devolução deve ser validado com a identidade acadêmica do aluno ou professor no Active Diretory   | ALTA |
| RF-003 | A aplicação deve possuir CRUD de Categoria de Itens  | ALTA |
| RF-004 | A aplicação deve possuir CRUD de Itens      | ALTA |
| RF-005 | A aplicação deve apresentar qual o código do usuário e nome tomador | MÉDIA |
| RF-006 | A aplicação deve registrar e apresentar a data e hora do emprestimo e devolução | MÉDIA |
| RF-007 | A aplicação deve registrar como observação o local foi colocado o equipamento    | BAIXA |

### Requisitos não Funcionais

| ID      | Descrição do Requisito   | Prioridade |
| ------- | ------------------------- | ---- |
| RNF-001 | A aplicação deve ser distribuída, permitindo o acesso em vários computadores conectados à rede | ALTA | 
| RNF-002 | A aplicação deve ser acessada apenas usuários técnicos/administrativos | ALTA | 
| RNF-003 | O sistema deve ser responsivo para rodar em dispositivos móveis | MÉDIA | 
| RNF-004 | Deve processar requisições do usuário em no máximo 3s |   BAIXA | 
| RNF-005 | A aplicação deve ser intuitiva |  BAIXA | 

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


## Diagrama de Casos de Uso

<center><img src="img/Diagrama%20de%20Caso%20de%20Uso.png" /></center>


## Modelo ER (Projeto Conceitual)

Será utilizado o banco de dados não relacional.

## Projeto da Base de Dados

<center><img src="img/Diagrama Banco de Dados.png" /></center>

### Diagrama de Classes

![Diagrama de classe](https://github.com/user-attachments/assets/7c74ac2f-04f8-4319-b4d8-05a59b05fbad)
