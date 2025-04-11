# HRLeaveManagement

# HRLeaveManagement

A Human Resource Leave Management System built using **.NET Core**, following the **Clean Architecture** principles with **CQRS**, **MediatR**, and **Entity Framework Core**. This solution helps manage leave requests, employee positions, and employment types in a modular and maintainable way.

---

## 🚀 Features

- Create, update, delete leave types and positions
- Handle employee leave requests
- Clean separation of concerns via CQRS
- Dependency Injection and Repository Pattern
- AutoMapper for DTO mapping
- Entity Framework Core for data access
- ASP.NET Core Web API
- Modular project structure

---

## 🏗️ Tech Stack

- **.NET 8** / **.NET 6**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **MediatR**
- **AutoMapper**
- **FluentValidation**
- **Clean Architecture**
- **CQRS**
- **Repository Pattern**
- **Swagger**

---

## 📁 Project Structure

Webapp/ │ ├── Core/ │ ├── Web.Application/ │ │ ├── Extensions/ # DI registration (ApplicationDIRegistration) │ │ ├── Features/ │ │ │ ├── Category/ │ │ │ ├── EmploymentType/ │ │ │ └── Position/ │ │ │ ├── Command/ # Commands (Create, Update, Delete) │ │ │ ├── Queries/ # Queries (GetAll, GetById) │ │ │ └── PositionDto.cs # DTO for Position entity │ │ ├── Interfaces/ │ │ │ └── IRepository.cs # Generic repository interface │ │ ├── BaseDto.cs # Base DTO class │ │ ├── BaseCommandQuery.cs # Shared CQRS base classes │ │ ├── Profiles/ # AutoMapper profiles (e.g., MappingProfile) │ │ └── Response/ # Optional response wrapping │ ├── Web.Domain/ │ └── Entities (e.g., Position.cs) # Domain models │ ├── Infrastructure/ │ ├── Repository/ # Implementation of IRepository<T> │ └── Data/ │ └── ApplicationDbContext.cs # EF Core DbContext │ ├── Presentation/ # Web API (Controllers, endpoints) │ └── Test/ # Unit/integration tests (optional)


---

## ⚙️ Setup Instructions

1. **Clone the repo**

```bash
git clone https://github.com/TaaniIIS/Clean-Architecture-Template.git
cd HRLeaveManagement

2. Configure SQL Server connection string
In appsettings.json or IConfiguration, ensure you have:

"ConnectionStrings": {
    "AppConnection": "Data Source=.;Initial Catalog=HR_LeaveManagement;Integrated Security=True;TrustServerCertificate=True;Trusted_Connection=True;Connection Timeout=30;"
}

3. Run EF Core Migrations
dotnet ef database update

4. Run the application
dotnet run

5. Explore the API with Swagger


🧠 Clean Architecture Highlights

    CQRS with MediatR – Commands for write operations, Queries for reads

    AutoMapper – Simplifies mapping between domain entities and DTOs

    Repository Pattern – Abstracts EF Core logic for testability

    Dependency Injection – Configured in ApplicationDIRegistration and AddInfrastructureServices

🛠 Example Technologies

    .NET 8 / .NET 6

    ASP.NET Core Web API

    MediatR

    AutoMapper

    EF Core

    FluentValidation (optional)

    SQL Server

    Swagger

👨‍💻 Author

Mustafe Sacad
Docker Captain 🐳 | AWS Community Builder ☁️ | DevOps Engineer ⚙️
LinkedIn | Twitter
🪪 License

Licensed under the MIT License. Free to use, modify, and distribute.


