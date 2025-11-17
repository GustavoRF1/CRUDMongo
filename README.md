# 📘 CRUD Básico em MongoDB com C# -- Console Application

Este projeto demonstra como realizar operações CRUD (Create, Read,
Update, Delete) utilizando **MongoDB** com **C#** em uma aplicação do
tipo **Console Application**.\
O sistema trabalha com duas collections relacionadas: **Authors** e
**Books**, permitindo a inserção, consulta, atualização e remoção de
documentos no MongoDB.

## 🚀 Tecnologias Utilizadas

-   **.NET 6+**
-   **MongoDB**
-   **MongoDB .NET Driver**
-   **C# (async/await)**

## 📂 Estrutura das Collections

### **Authors**

| Campo   | Tipo     | Descrição                                      |
|---------|----------|------------------------------------------------|
| Id      | ObjectId | Identificador único gerado automaticamente     |
| Name    | string   | Nome do autor                                  |
| Country | string   | País de origem                                 |

### **Books**

| Campo    | Tipo     | Descrição                                      |
|----------|----------|------------------------------------------------|
| Id       | ObjectId | Identificador único                            |
| Title    | string   | Título do livro                                |
| AuthorId | ObjectId | Referência ao autor (FK)                       |
| Year     | int      | Ano de publicação                              |

## 🧠 Funcionalidades Implementadas (CRUD)

### ✔ Create

-   Inserção de autor
-   Inserção de livro

### ✔ Read

-   Listar autores
-   Listar livros

### ✔ Update

-   Atualizar informações de um autor
-   Atualizar informações de um livro

### ✔ Delete

-   Remover um livro
-   Remover um autor

## ⚙️ Como Executar

### 1. Instalar MongoDB

https://www.mongodb.com/try/download/community

### 2. Instalar .NET SDK

https://dotnet.microsoft.com/download

### 3. Clonar

``` bash
git clone https://github.com/GustavoRF1/CRUDMongo.git
cd CRUDMongo
```

### 4. Instalar driver MongoDB

``` bash
dotnet add package MongoDB.Driver
```

### 5. Rodar

``` bash
dotnet run
```
