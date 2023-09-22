## Setup .net 6.0 web api
   - dotnet new webapi -n api

## Setup react app
   - npm install -g create-react-app
   - npx create-react-app my-app --template typescript

## NuGet packages
   - dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 6.0.10
   - dotnet add package Microsoft.EntityFrameworkCore --version 6.0.22
   - dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.22
   - dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.0
   - dotnet add package Dapper --version 2.0.151
   - dotnet add package System.Data.SqlClient --version 4.8.5
   

## packages
   - npm install axios  -- Axios is used to make HTTP requests to your .NET 6 API

## Start api
   - dotnet run
   - docker build -t test-image .
   - docker run -d -p 5000:80 --name test-container test-image
   - docker-compose up

## Start web
   - npm start
   - docker build -t react-app .
   - docker run -p 3000:3000 react-app
   - docker-compose up


src/
  |- components/
  |   |- StudentList.tsx
  |   |- AddStudent.tsx
  |   |- UpdateStudent.tsx
  |   |- DeleteStudent.tsx
  |
  |- services/
  |   |- api.tsx
  |   |- StudentService.tsx
  |
  |- models/
  |   |- Student.tsx
  |
  |- utils/
  |   |- helpers.tsx
  |
  |- App.tsx
  |- index.tsx


While it's possible to manage state and create components without using hooks in React, hooks are the recommended and modern way to handle component state. React introduced hooks as a way to manage stateful logic in functional components.

- Napravili smo crud operacije gde za citanje koristimo dapper jer je brzi od EF
Linq je sporiji od klasicnog foreach loop-a
Preko linq samo dobavljam podatke iz baze i upisujem ih
I ne bi trebalo koristiti linq za rad sa listama i podacima jer je foreacg pelja braza neko da se koristilinq

DB migration
dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialMigration
dotnet ef database update





1. Za .net kerisranje i exception handling, logger
2. React pokusati da skapiras hooks i lifecucel of components
3. Vratiti se na JS kurs pa nek populacija baze bude jedan deo kursa