# Тестовое задание.

Для запуска бекенда:
  Перейти в backend/ContractSystems
  Из каталога в консоли прописать:
  ```
  docker-compose -f .\compose.yml -f .\docker-compose.yml --verbose up --build
  ```
  АПИ доступно по адресу: http://localhost:80/
  Swagger: http://localhost:80/swagger/index.html
Для запуска фронтента:
  Перейти в client/
  Из каталога в консоли прописать:
  ```
  npm i
  npm run dev
  ```
  Приложение доступно по адресу: http://localhost:8001/

На фронте использую:
  Next JS, React, TypeScript
На бекенде:
  .NET 8, EFCore
