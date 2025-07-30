# 🦉 Coruja Express - Sistema de Autoatendimento para Mercados

![Banner do Coruja Express](https://placehold.co/1200x400/4a148c/ffab00?text=Coruja+Express&font=inter)

### Um sistema de ponto de venda (PDV) completo, projetado para mercados de autoatendimento (*honest market*).

---

## 🎯 Sobre o Projeto

O **Coruja Express** foi desenvolvido para ser uma solução intuitiva, robusta e de fácil gerenciamento para mercados autônomos, ideal para ambientes com grande fluxo de pessoas, como condomínios, empresas e universidades.

O projeto é composto por três componentes principais:
1.  **Totem de Autoatendimento:** A interface do cliente, focada na simplicidade e rapidez.
2.  **Painel Administrativo:** Uma ferramenta web para os gestores controlarem o negócio.
3.  **API Backend:** O cérebro do sistema, que centraliza toda a lógica de negócio.

---

## ✨ Funcionalidades Principais

### 🛒 Totem de Autoatendimento (Cliente)
-   **Interface Intuitiva:** Construído com **React JS** para uma experiência de usuário fluida e moderna.
-   **Busca de Produtos:** Filtro de produtos dinâmico que funciona em tempo real.
-   **Carrinho de Compras Interativo:** Adicione, remova e altere a quantidade de itens com atualização instantânea do valor total.
-   **Pagamento Simplificado:** Finalização da compra com a exibição de um **QR Code PIX** para um pagamento rápido e sem contato.

### ⚙️ Painel Administrativo (Gestor)
-   **Gerenciamento de Produtos:** Adicione, edite e gerencie todos os produtos através de uma interface visual.
-   **Controle de Estoque:** O sistema deduz automaticamente os itens do estoque a cada venda realizada.
-   **Histórico de Vendas:** Visualize um registro detalhado de todas as transações, incluindo itens, data e valor total.

### 🚀 API Robusta (Backend)
-   **Lógica Centralizada:** Desenvolvida com **.NET e C#**, a API gerencia todas as regras de negócio e a comunicação com o banco de dados.
-   **Arquitetura RESTful:** Segue os padrões de mercado para uma comunicação eficiente e escalável.
-   **Segurança de Dados:** Utiliza transações para garantir a consistência dos dados, principalmente na atualização de estoque e registro de vendas.

---

## 🛠️ Tecnologias Utilizadas

O projeto foi construído utilizando uma stack de tecnologias moderna e amplamente utilizada no mercado:

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![React](https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white)

---

## 🚀 Como Executar o Projeto

### **1. Backend (API)**
   - Clone o repositório.
   - Navegue até a pasta do projeto da API:
     ```bash
     cd CorujaExpress.Api
     ```
   - Instale as dependências:
     ```bash
     dotnet restore
     ```
   - Inicie o servidor:
     ```bash
     dotnet run
     ```

### **2. Frontend (Totem e Admin)**
   - Certifique-se de que a constante `API_URL` nos arquivos `index.html` e `admin.html` aponta para o endereço correto do backend em execução.
   - Abra os arquivos `index.html` (totem) e `admin.html` (painel) diretamente em um navegador web.

---

## 👨‍💻 Autores

Este projeto foi idealizado e desenvolvido com muito carinho por:

* **Giovana Kaori**

Dedicado com muito amor, ao seu namorado, Vinicius Carneiro Tiburcio Narenti.
