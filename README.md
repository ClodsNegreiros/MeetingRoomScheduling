# Gerenciamento de Reservas de Salas

## 📌 Sobre o Projeto
O projeto Meeting Room Scheduling tem como objetivo fornecer uma API para o gerenciamento de usuários, salas e reservas de salas, garantindo controle sobre os cadastros, autenticação e validação de conflitos de horários.

## 🚀 Tecnologias Utilizadas
- .NET
- PostgreSQL
- Entity Framework Core
- Swagger
- MediatR
- Clean Architecture
- CQRS (Command Query Responsibility Segregation)

## 🏗️ Arquitetura
O projeto segue os princípios da **Clean Architecture**, separando responsabilidades entre as camadas **Application, Domain, Infrastructure e WebAPI**. Utiliza o padrão **CQRS** para separar operações de leitura e escrita, implementado com o **MediatR** para desacoplamento entre os handlers de comandos e queries.

## ⚙️ Funcionalidades

### 1. Gerenciamento de Usuários
- Criar, editar e excluir usuários
- Cada usuário deve ter nome, e-mail e senha para registro

### 2. Autenticação de Usuários
- Login com autenticação via JWT
- Proteção de endpoints por autenticação

### 3. Gerenciamento de Salas
- Criar, editar e excluir salas
- Definir nome e capacidade máxima de cada sala

### 4. Gerenciamento de Reservas
- Criar, listar e cancelar reservas de salas
- Validação de conflitos de horários (não permitir reservas sobrepostas para a mesma sala)
- As reservas devem iniciar e finalizar no mesmo dia

### 5. Listagem de Reservas
- Buscar reservas por usuário e sala
- Permitir filtros por data e status (ativa/cancelada)

## 📌 Como Executar o Projeto

### 📦 Pré-requisitos
- [.NET 9](https://dotnet.microsoft.com/download/dotnet)
- [PostgreSQL](https://www.postgresql.org/download/)

### 🔧 Configuração
1. Clone o repositório:
   ```bash
   git clone https://github.com/ClodsNegreiros/MeetingRoomScheduling.git
   cd MeetingRoomScheduling
   ```
2. Configure a string de conexão no **appsettings.json**:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=reservas;Username=postgres;Password=senha"
   }
   ```
3. Execute as migrations:
   ```bash
   dotnet ef database update
   ```
4. Rode o projeto:
   ```bash
   dotnet run
   ```

A API será iniciada nas portas configuradas no `launchSettings.json`:
- HTTP: `http://localhost:5166`
- HTTPS: `https://localhost:7203`

## 📖 Documentação da API
Após iniciar a aplicação, a documentação Swagger será aberta automaticamente e estará disponível em:
```
https://localhost:7203/swagger
```
