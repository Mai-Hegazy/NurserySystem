# 🌱 NurserySystem

A complete management system for nursery operations built using **ASP.NET Core** with a clean architecture approach. This system helps manage child enrollment.

## 🏗️ Architecture

The project follows **Clean Architecture** principles, with distinct layers for separation of concerns:

NurserySystem.API → Web API entry point
NurserySystem.Application → Business logic and services
NurserySystem.Domain → Entities and interfaces
NurserySystem.Infrastructure → Database access and external service implementations
NurserySystem.Client → Angular frontend

## ⚙️ Technologies Used

- **Backend**:
  - ASP.NET Core
  - Entity Framework Core
  - SQL Server
  - Clean Architecture
- **Frontend**:
  - Angular
- **Other Tools**:
  - Git for version control
  - VS Code for development
  - QLite Database for local data storage 

## 🚀 Getting Started

Follow these steps to set up the project locally:

### 1. Clone the repository

git clone https://github.com/Mai-Hegazy/NurserySystem.git

### 2. Install dependencies
For the API backend, ensure you have Visual Studio or VS Code installed with the required extensions.

Install NuGet dependencies for the backend and frontend (if any).

### 3. Configure the Database
Make sure your database is set up and connection strings are configured in appsettings.json for SQL Server.

Run migrations:
  dotnet ef database update

### 4. Run the project
  Set NurserySystem.API as the startup project.

Run the project, and the API should be available on the specified URL (e.g., https://localhost:5001).

### 5. Frontend

Go to the ClientApp folder.

Install dependencies and run the client:
npm install
npm start

## 🧩 Features
Child Enrollment: Add and manage children’s details.

Modular Structure: The project is modular and easily extendable for more features in the future.

Clean Architecture: Maintainable and testable code with separate layers for each responsibility.

## 👨‍💻 Author
Created by Mai Hegazy
Feel free to connect via LinkedIn (https://www.linkedin.com/in/mai-hegazy/).

