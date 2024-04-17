### 💻 Projeto DevFreela

Este projeto foi criado e desenvolvido durante o curso Formação ASP.Net Core do [Luis Dev](https://www.linkedin.com/in/luisdeol/).

O objetivo do projeto é compreender o uso dos recursos utilizados durante o desenvolvimento, construindo uma API REST de forma bastante completa.
No decorrer do desenvolvimento do projeto e absorção de conhecimento foram utilizados os recursos abaixo:

• ASP.NET Core
• Arquitetura Limpa
• Microsserviços
• Dapper
• Documentação com Swagger
• CQRS
• Entity Framework Core
• Testes unitários com XUnit
• Azure Devops
• Azure Pipelines
• Mensageria com RabbitMQ
• Padrão Repository
• Autenticação e Autorização com JWT
• MySQL
• API REST

No projeto é possível

• Criar, Pesquisar, Atualizar e Deletar Projetos
• Criar, Carregar e Atualizar Usuários

---

### 📫 Rotas

- Projects Controller

<img src="https://img.shields.io/badge/-GET-%2361AFFE" height="20" />

**"/api/projects"**

_Get all Projects_

**required headers:**

`Authorization: Bearer {token JWT}`

**roles:**

`"client", "freelancer"`

**query params:**

`query?: string`

**response:**

```
[
  {
     "id": int,
     "title": string,
     "createdAt": DateTime
  }
]
```

<hr>

<img src="https://img.shields.io/badge/-GET-%2361AFFE" height="20" />

**"/api/projects/{id}"**

_Get Project by your id_

**required headers:**

`Authorization: Bearer {token JWT}`

**roles:**

`"client", "freelancer"`

**route params:**

`id: int`

**response:**

```
{
  "id": int,
  "title": string,
  "description": string,
  "totalCost": decimal,
  "startedAt"?: DateTime,
  "finishedAt"?: DateTime,
  "clientFullName": string,
  "freelancerFullName": string
}
```

<hr>

<img src="https://img.shields.io/badge/-POST-%2349CC90" height="20" />

**"/api/projects"**

_Create a new Project_

**required headers:**

`Authorization: Bearer {token JWT}`

**roles:**

`"client"`

**body:**

```
{
   "title": string,
   "description": string,
   "idClient": int,
   "idFreelancer": int,
   "totalCost": decimal
}
```

**response:**

```
{
   "title": string,
   "description": string,
   "idClient": int,
   "idFreelancer": int,
   "totalCost": decimal
}
```

<hr>

<img src="https://img.shields.io/badge/-POST-%2349CC90" height="20" />

**"/api/projects/{id}/comments"**

_Adds a comment to an existing project using your id_

**required headers:**

`Authorization: Bearer {token JWT}`

**roles:**

`"client", "freelancer"`

**route params:**

`id: int`

**body:**

```
{
   "content": string,
   "idProject": int,
   "idUser": int
}
```

**response:**
_No content_

<hr>

<img src="https://img.shields.io/badge/-PUT-%23FCA130" height="20" />

**"/api/projects/{id}"**

_Update a Project by your id_

**required headers:**

`Authorization: Bearer {token JWT}`

**roles:**

`"client"`

**route params:**

`id: int`

**body:**

```
{
  "id": int,
  "title": string,
  "description": string,
  "totalCost": decimal
}
```

**response:**
_No content_

<hr>

<img src="https://img.shields.io/badge/-PUT-%23FCA130" height="20" />

**"/api/projects/{id}/start"**

_Changes the status of a project to "InProgress" by your id_

**required headers:**

`Authorization: Bearer {token JWT}`

**roles:**

`"client"`

**route params:**

`id: int`

**response:**
_No content_

<hr>

<img src="https://img.shields.io/badge/-PUT-%23FCA130" height="20" />

**"/api/projects/{id}/finish"**

_Changes the status of a project to "PaymentPending" by your id and sends a message to the payment microservice using RabbitMQ_

**required headers:**

`Authorization: Bearer {token JWT}`

**roles:**

`"client"`

**route params:**

`id: int`

**body:**

```
{
  "idProject": int,
  "creditCardNumber": string,
  "cvv": string,
  "expiresAt": string,
  "fullName": string,
  "amount": decimal
}
```

**response:**
_Accepted_

<hr>

<img src="https://img.shields.io/badge/-DELETE-%23F93E3E" height="20" />

**"/api/projects/{id}"**

_Delete a project by your id_

**required headers:**

`Authorization: Bearer {token JWT}`

**roles:**

`"client"`

**route params:**

`id: int`

**response:**
_No content_

<hr>

- Skills Controller

<img src="https://img.shields.io/badge/-GET-%2361AFFE" height="20" />

**"/api/skills"**

_Get all Skills_

**response:**

```
[
  {
     "id": int,
     "description": string
  }
]
```

<hr>

- Users Controller

<img src="https://img.shields.io/badge/-GET-%2361AFFE" height="20" />

**"/api/users/{id}"**

_Get a User by your id_

**required headers:**

`Authorization: Bearer {token JWT}`

**route params:**

`id: int`

**response:**

```
{
  "fullName": string,
  "email": string
}
```

<hr>

<img src="https://img.shields.io/badge/-POST-%2349CC90" height="20" />

**"/api/users"**

_Register a new User_

**body:**

```
{
  "fullName": string,
  "password": string,
  "email": string,
  "birthDate": DateTime,
  "role": string
}
```

**response:**

```
{
  "fullName": string,
  "password": string,
  "email": string,
  "birthDate": DateTime,
  "role": string
}
```

<hr>

<img src="https://img.shields.io/badge/-PUT-%23FCA130" height="20" />

**"/api/users/login"**

_Generate a new JWT token_

**body:**

```
{
  "email": string,
  "password": string
}
```

**response:**

```
{
  "email": string,
  "token": string
}
```

---

### 🌐 Status do Projeto

Finalizado, mas sempre com possibilidades de ajustes. ✅

---

### 🔨 Ferramentas utilizadas

<div>
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" width="50" /> 
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" width="50" />
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/mysql/mysql-original-wordmark.svg" width="50" />
<img src="https://cdn.freebiesupply.com/logos/large/2x/rabbitmq-logo-png-transparent.png" height="50" />
</div>
