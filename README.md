## Setup .net 6.0 web api
   - dotnet new webapi -n api

## Setup react app
   - npm install -g create-react-app
   - npx create-react-app my-app --template typescript

## NuGet packages
   - dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 6.0.10

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