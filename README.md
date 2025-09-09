# 🏪 Developer Store 🏪

API de gerenciamento de **Usuários, Produtos e Vendas**, desenvolvida em **.NET 7** com **DDD, CQRS e Clean Architecture**.  
Banco principal: **PostgreSQL** | Auditoria/Logs: **MongoDB**.  
Documentação interativa via **Swagger**.

---

## 🚀 Tecnologias
- .NET 7, Entity Framework Core  
- PostgreSQL, MongoDB  
- CQRS + MediatR  
- AutoMapper, FluentValidation  
- Swagger / OpenAPI  

---

## 📂 Estrutura
- **Domain** → Entidades, regras de negócio, Value Objects  
- **Application** → Casos de uso (CQRS), validações, perfis de mapeamento  
- **Infrastructure** → Repositórios, EF Core, Migrations  
- **WebApi** → Controllers, Requests/Responses, Middlewares  
- **Tests** → Testes unitários e de integração  

---

## ⚙️ Configuração
1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/developer_store.git
   cd developer_store

2. Configure o banco em appsettings.json (WebApi):
   ```bash
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5432;Database=SEU_BANCO;Username=SEU_USUARIO;Password=SUA_SENHA"
   }

3. Rode as Migrations:
   ```bash
   dotnet ef migrations add InitDatabase -p src/Ambev.DeveloperEvaluation.ORM -s src/Ambev.DeveloperEvaluation.WebApi
   dotnet ef database update -p src/Ambev.DeveloperEvaluation.ORM -s src/Ambev.DeveloperEvaluation.WebApi

4. Execute a aplicação:
   ```bash
   dotnet run --project src/Ambev.DeveloperEvaluation.WebApi

👉🏻 Swagger: https://localhost:7181/swagger

---

## 📖 Endpoints
# Users

POST /api/Users → Criar

GET /api/Users/{id} → Buscar

DELETE /api/Users/{id} → Remover

# Products

POST /api/Products → Criar

PUT /api/Products/{id} → Atualizar

GET /api/Products → Listar (pagina/ordenação)

GET /api/Products/{id} → Buscar

DELETE /api/Products/{id} → Remover

GET /api/Products/Categories → Listar categorias (pagina/ordenação)

GET /api/Products/Category/{id} → Listar (pagina/ordenação)

# Sales

POST /api/Sales → Criar (com descontos progressivos)

PUT /api/Sales/{id} → Atualizar

PUT /api/Sales/{id}/cancel → Cancelar

GET /api/Sales → Listar (pagina)

GET /api/Sales/{id} → Buscar

# Carts

POST /api/Carts → Criar 

PUT /api/Carts/{id} → Atualizar

DELETE /api/Carts/{id} → rEMOVER

GET /api/Carts → Listar (pagina)

GET /api/Carts/{id} → Buscar

---

## ✅ Regras de Negócio

Descontos em vendas:

4 a 9 itens → 10%

10 a 20 itens → 20%

20 itens → inválido

Cancelamento bloqueia atualizações

Produtos têm rating (média + contagem)

Paginação e ordenação em listagens
