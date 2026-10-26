# TaskManager

Пет-проект: ASP.NET Core Web API (.NET 10), React и TypeScript.
Рабочий корень: `D:\TaskManager\TaskManager`. Открывайте `TaskManager.slnx`.
Git охватывает всё решение.

## Структура и зависимости

- **TaskManager.Api** — Controllers, DTOs, Middlewares, Program.cs. Ссылается на Core и Infrastructure.
- **TaskManager.Core** — Entities, Interfaces, Enums. Не зависит от API и EF Core.
- **TaskManager.Infrastructure** — Data/Configurations, Data/Scripts, Repositories, Migrations. Ссылается на Core.
- **TaskManager.Client** — React + TypeScript + Vite. Обращается к API по HTTP.
  - src/components — общие компоненты.
  - src/features — функциональные модули (доска, задачи, проекты).
  - src/services — HTTP-вызовы.
  - src/store — состояние приложения.
  - src/types — TypeScript-типы.
  - src/App.tsx — корневой компонент; в дальнейшем здесь подключается роутинг.
  - src/main.tsx — точка входа.
- **docs/project-vision.md** — исходное описание планов, а не перечень готовых возможностей.

Пустые папки сохранены через `.gitkeep`. После добавления кода их можно удалить.
В Обозревателе решений клиент показан как папка решения с основными файлами.
Для просмотра всех его каталогов откройте папку клиента в редакторе.

## Запуск

Нужны .NET SDK 10 и Node.js 22.12+ и pnpm 11.25.0 (установка: npm install -g pnpm@11.25.0). Backend нацелен на `net10.0`.

Из корня решения:

```powershell
dotnet restore TaskManager.slnx
dotnet build TaskManager.slnx
dotnet run --project TaskManager.Api --launch-profile http
```

Тестовый endpoint: `http://localhost:5218/weatherforecast`.

В отдельном терминале:

```powershell
cd TaskManager.Client
pnpm install --frozen-lockfile
pnpm dev
```

Клиент: `http://localhost:5173`. Vite проксирует `/api` и `/weatherforecast` на backend при разработке. Маршруты `/api` пока не реализованы.
Для production адрес API и размещение клиента настраиваются отдельно.

Проверка клиента: `pnpm typecheck`. Сборка: `pnpm build`.
Конфигурация основана на официальном [шаблоне Vite React TypeScript](https://github.com/vitejs/vite/tree/main/packages/create-vite/template-react-ts).

## Дальнейшая работа

Подготовлены структура, проектные ссылки и минимальная стартовая страница клиента. Сохранён тестовый WeatherForecast API.

1. Создать девять сущностей по `TaskManager.Infrastructure/Data/Scripts/init_schema.sql`.
2. Добавить перечисления и контракты репозиториев в Core.
3. Подключить EF Core и SQL Server, создать DbContext и конфигурации.
4. Настроить строку подключения через User Secrets или переменные окружения, затем миграции.
5. Реализовать API и клиентские модули.

SQL-скрипт сохранён без изменений и автоматически не выполняется.
EF Core, DbContext, миграции, React Router и бизнес-функции пока не реализованы.
