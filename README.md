# DapperCrudPlayground

A minimal .NET API utilizing **Dapper** for database access — my first hands-on experience with Dapper.  
The goal was to build a very simple CRUD API to explore the basic capabilities of this lightweight ORM.

All code was written without the use of any large language models — just good old-fashioned research through documentation, previous projects, StackOverflow, and blog posts.

---

### 🏛️ Solution Overview

A lightweight, minimal API written in a clean and straightforward way. Endpoints are built on top of a service layer.

- The `MovieService` uses an abstraction for creating `DbConnection` instances with Dapper.
- Business logic for CRUD operations is encapsulated in the service.
- Mapster is used for simple object mapping between DTOs and domain models.

---

### 📚 API Endpoints

| Method | Endpoint         | Description                         |
|--------|------------------|-------------------------------------|
| GET    | `/movies`        | Retrieves the full list of movies  |
| GET    | `/movies/{id}`   | Retrieves a specific movie by GUID |
| POST   | `/movies`        | Adds a new movie                   |
| PUT    | `/movies/{id}`   | Updates an existing movie          |
| DELETE | `/movies/{id}`   | Deletes a movie by ID              |

---

### 🛠️ Technologies Used
- .NET 8
- Dapper
- Mapster
- Minimal API
- Docker
- MSSQL

---

### ⚙️ Setup Instructions

1. Clone the repository:
```bash
git clone git@github.com:MichalZdanuk/DapperCrudPlayground.git
cd DapperCrudPlayground
```
2. Run docker compose with whole app configured:
```bash
docker-compose up -d
```
3. Connect with DB, create MoviesDb and run *init.sql* script
```bash
sqlcmd -S localhost,1488 -U SA -P <DbPassword> -i .\DapperDemo\DapperCrudPlayground\init.sql
```

Aplication is available on: https://localhost:6000 and https://localhost:6060

---

### 🔍 References and research
While developing project I found usefull these resources:
- 🎥 [Nick Chapsas tutorial on Getting Started with Dapper in .NET](https://www.youtube.com/watch?v=F1ONxvjdLlc&ab_channel=NickChapsas) - inspired me to build this project
- ✍️ [Blog post about .NET minimal APIs on Medium](https://medium.com/codenx/minimal-apis-in-net-8-a-simplified-approach-to-build-services-eb50df56819f)
- 📖 [Documentation page on setting up Dapper](https://www.learndapper.com/database-providers)
- 📖 [Documentation page on executing commands](https://www.learndapper.com/non-query)
