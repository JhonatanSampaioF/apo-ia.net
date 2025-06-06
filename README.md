
# 🧠 Apo.IA — Sistema de Apoio a Centros Humanitários (.NET Edition)

## 📌 Descrição do Projeto

O **Apo.IA** é um sistema completo desenvolvido com **C# e ASP.NET Core**, voltado à gestão de pessoas em centros humanitários. A aplicação permite o cadastro e acompanhamento de **abrigados**, **voluntários**, **doenças**, **habilidades** e **locais de acolhimento**. Utiliza **ML.NET** para oferecer sugestões automatizadas de alocação de voluntários conforme suas habilidades.

A arquitetura do sistema segue o padrão em **camadas** (Controllers, Services, DTOs, Repositories e Data), com integração ao **Entity Framework Core 8** e persistência em banco de dados relacional (Oracle ou similar).

---

## 🚀 Tecnologias Utilizadas

| Camada        | Tecnologias                                                   |
|---------------|---------------------------------------------------------------|
| Backend       | ASP.NET Core 8, Entity Framework Core, ML.NET                 |
| Banco de Dados| Oracle Entity Framework Core                                  |
| Documentação  | Swagger (Swashbuckle.AspNetCore)                              |
| Testes        | xUnit, coverlet                                               |

---

## ▶️ Como Executar o Projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/JhonatanSampaioF/apo-ia-dotnet.git
cd apo-ia-dotnet
```

### 2. Configurar banco de dados

Configure a connection string no arquivo `appsettings.json` com os dados do seu banco Oracle local ou servidor.

### 3. Executar as migrações e rodar a aplicação

```bash
dotnet ef database update
dotnet run
```

A aplicação estará disponível em:

- `https://localhost:5001`
- `http://localhost:5000`

---

## 📚 Documentação dos Endpoints

A documentação está disponível automaticamente via Swagger após iniciar a aplicação:

🔗 [https://localhost:5001/swagger](https://localhost:5001/swagger)

### Endpoints principais:

- `GET /doenca` – Lista doenças
- `POST /doenca` – Cadastra doença
- `GET /doenca/{id}` – Lista uma doença
- `PUT /doenca/{id}` – Edita uma doença
- `DELETE /doenca/{id}` – Deleta uma doença

- `GET /grupoHabilidade` – Lista grupo de habilidades
- `POST /grupoHabilidade` – Cadastra grupo de habilidade
- `GET /grupoHabilidade/{id}` – Lista um grupo de habilidade
- `PUT /grupoHabilidade/{id}` – Edita um grupo de habilidade
- `DELETE /grupoHabilidade/{id}` – Deleta um grupo de habilidade

- `GET /habilidade` – Lista habilidades
- `POST /habilidade` – Cadastra habilidade
- `GET /habilidade/{id}` – Lista uma habilidade
- `PUT /habilidade/{id}` – Edita uma habilidade
- `DELETE /habilidade/{id}` – Deleta uma habilidade

- `GET /local` – Lista local
- `POST /local` – Cadastra local
- `GET /local/{id}` – Lista um local
- `PUT /local/{id}` – Edita um local
- `DELETE /local/{id}` – Deleta um local

- `GET /abrigado` – Lista todos os abrigados
- `POST /abrigado` – Cadastra novo abrigado
- `GET /abrigado/{id}` – Lista um abrigado
- `PUT /abrigado/{id}` – Edita um abrigado
- `DELETE /abrigado/{id}` – Deleta um abrigado

- `GET /voluntario` – Lista voluntários
- `POST /voluntario` – Cadastra voluntário
- `GET /voluntario/{id}` – Lista um voluntário
- `PUT /voluntario/{id}` – Edita um voluntário
- `DELETE /voluntario/{id}` – Deleta um voluntário

- `POST /recommendation` – Responde perguntas abertas sobre alocação

---

## 🧪 Instruções de Testes

### 1. Executar todos os testes com cobertura:

```bash
dotnet test --collect:"XPlat Code Coverage"
```

### 2. Visualizar cobertura no Visual Studio:

- Menu `Testes > Analisar cobertura de código`
- Veja os percentuais por método e classe

### 3. Estrutura de Testes

Os testes estão organizados por entidade e DTO em:

```
apo-ia.net.Tests/
├── AbrigadoTests.cs
├── DoencaTests.cs
├── GrupoHabilidadeTests.cs
├── HabilidadeTests.cs
├── LocalTests.cs
├── VoluntarioTests.cs
├── RecommendationServiceTests.cs
```

Cada classe testa:

- Criação da entidade e seus relacionamentos
- Validação das regras básicas de negócio
- Execução de serviços com dependências simuladas

---

## 👨‍💻 Equipe de Desenvolvimento

| Nome                 | Função               | RM        |
|----------------------|----------------------|-----------|
| Jhonatan Sampaio     | Backend Developer    | RM553791  |
| Gustavo Vieira Bargas| Database Analyst     | RM553471  |
| Vivian Sy Ting Wu    | Frontend Developer   | RM553169  |

> 📚 Projeto desenvolvido para a disciplina de .NET da FIAP — 4º semestre, com foco em soluções de impacto social no contexto do Global Solution.
