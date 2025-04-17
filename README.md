# DapperCrudPlayground
.NET minimal API utilizing Dapper for connection to DB (my first contact with Dapper). Idea was to create very simple API and test basic posssibilities. Writing API witout usage of any LLM, just basing on previous projects, StackOverflow, blog posts and documentation.

### 🏛️ Solution
Lighweight minimal API written in clean yet very simple way. Endpoints utilize service. Movie Servies uses abstraction that allows to create dbConnection using Dapper. In service implementation resides business logic for performing CRUD operations. Also used Mapster for very simple DTO -> model and model -> DTO mappings.

List of endpoints:
- *GET /movies* = retrieves all movies list
- *GET /movies/id* = retrieves specific movie, identified by unique GUID
- *POST /movies* = adds movie to db
- *PUT /movies/id* = modifies specified movie
- *DELETE /movies/id* = deletes specified movie

### 🛠️ Technologies Used
- Dapper
- Mapster
- MinimalAPI

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
3. Connect with DB, create MoviesDb and run init.sql sccript

Aplication is available on: https://localhost:6000 and https://localhost:6060

### 🔍 References and research
While developing project I found usefull these resources:
- [Nick Chapsas tutorial on Getting Started with Dapper in .NET](https://www.youtube.com/watch?v=F1ONxvjdLlc&ab_channel=NickChapsas) - inspired me to build this project
- [Blog post about .NET minimal APIs on Medium](https://medium.com/codenx/minimal-apis-in-net-8-a-simplified-approach-to-build-services-eb50df56819f)
- [Documentation page on setting up Dapper](https://www.learndapper.com/database-providers)
- [Documentation page on executing commands](https://www.learndapper.com/non-query)
