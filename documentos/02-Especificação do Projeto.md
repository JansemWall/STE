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

<center><img src="img/diagrama-arquitetura.png" alt="" width="350"/></center>

## Project Model Canvas

Colocar a imagem do modelo construído apresentando a proposta de solução.

> **Links Úteis**:
> Disponíveis em material de apoio do projeto

## Requisitos

As pessoas retratadas durante o processo de compreensão do problema são apresentadas nas figuras que seguem.

### Lucas Arcanjo
**Idade:** 22 anos<br>
**Ocupação:** Auxiliar de TI<br>
**Frustrações:** O programa é lento e pouco intuitivo.<br>
**Motivação:** Facilitar o uso e diminuir a lentidão do aplicativo.<br>

---

### Heitor Flávio
**Idade:** 23 anos<br>
**Ocupação:** Auxilar de TI<br>
**Frustrações:** A necessidade de reter documento do aluno para ceder empréstimo é pouco eficiente.<br>
**Motivação:** O sistema efetuando a validação do usuário pelas credênciais de acesso de aluno/professor facilita o controle e segurança do setor e dos clientes.<br>

---


### Lucas Felipe
**Idade:** 24 anos<br>
**Ocupação:** Técnico <br>
**Hobbies:** Robótica<br>
**Frustrações:** Tive muita dificuldade quando entrei na empresa para aprender como funcionava o sistema. <br>
**Motivação:** Ter um sistema mais leve e fácil manipulação.<br>

---

### Marcos
**Idade:** 24 anos<br>
**Ocupação:** Funcionário<br>
**Hobbies:** Plantação<br>
**Frustrações:** O sistema legado roda somente em um computador, pois o mesmo usa um banco de dados local, se este único computador der problema... putz.<br>
**Motivação:** Permitir que o sistema rode em uma versão web para que todos possamos acessar em vários computadores.<br>

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto. Para determinar a prioridade de requisitos, aplicar uma técnica de priorização de requisitos e detalhar como a técnica foi aplicada.

### Requisitos Funcionais

| ID     | Descrição do Requisito   | Prioridade |
| ------ | ----------------------------------------- | ---- |
| RF-001 | A aplicação deve ser distribuída, permitindo o acesso em vários computadores conectados à rede | ALTA | 
| RF-002 | A aplicação deve permitir o empréstimo e devolução de equipamentos de informática   | ALTA |
| RF-003 | A aplicação deve ser acessada apenas usuários técnicos/administrativos | ALTA | 
| RF-004 | A aplicação deve ser pelo menos um usuário técnico/administrativo com papel de Administrador do sistema | ALTA | 
| RF-005 | O empréstimo deve ser validado com a identidade acadêmica do aluno ou professor    | ALTA |
| RF-006 | A devolução deve ser validada com a identificação do acadêmico do aluno ou professor | ALTA | 
| RF-007 | A aplicação deve permitir o cadastro de novos itens    | ALTA |
| RF-008 | A aplicação deve permitir a edição de itens | ALTA | 
| RF-009 | A aplicação deve permitir a exclusão de itens   | ALTA |
| RF-010 | A aplicação deve apresentar qual o código do usuário tomador | MÉDIA |
| RF-011 | A aplicação deve apresentar qual o código do nome tomador | MÉDIA |
| RF-012 | A aplicação deve registrar a data e hora do emprestimo | MÉDIA |
| RF-013 | A aplicação deve registrar a data e hora da devolução | MÉDIA |
| RF-014 | A aplicação deve apresentar a data e hora do emprestimo | MÉDIA |
| RF-015 | A aplicação deve apresentar a data e hora da devolução | MÉDIA |
| RF-016 | A aplicação deve apresentar em qual local foi colocado o equipamento    | BAIXA |

### Requisitos não Funcionais

| ID      | Descrição do Requisito   | Prioridade |
| ------- | ------------------------- | ---- |
| RNF-001 | O sistema deve ser responsivo para rodar em dispositivos móveis | MÉDIA | 
| RNF-002 | Deve processar requisições do usuário em no máximo 3s |   BAIXA | 
| RNF-003 | A aplicação deve ser intuitiva |  BAIXA | 

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


## Diagrama de Casos de Uso

![Diagrama de casos de uso](img/CasosdeUso.drawio.jpg)


## Modelo ER (Projeto Conceitual)

O Modelo ER representa através de um diagrama como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa.

Sugestão de ferramentas para geração deste artefato: LucidChart e Draw.io.

A referência abaixo irá auxiliá-lo na geração do artefato “Modelo ER”.

> - [Como fazer um diagrama entidade relacionamento | Lucidchart](https://www.lucidchart.com/pages/pt/como-fazer-um-diagrama-entidade-relacionamento)

## Projeto da Base de Dados

O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.
