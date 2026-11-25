# TaskManager — система управления IT-проектами и задачами

**TaskManager** — курсовой проект по разработке веб-приложения для управления IT-проектами, задачами и командной работой.

Система предусматривает создание проектов, распределение задач между сотрудниками, управление сроками выполнения и визуализацию рабочего процесса с помощью Kanban-доски.

## Технологический стек

**Backend:**
- C# / .NET 10
- ASP.NET Core Web API
- Entity Framework Core 10
- Microsoft SQL Server
- JWT (планируется)

**Frontend:**
- React
- TypeScript
- Vite
- Kanban Drag-and-Drop (планируется)

**Инструменты разработки:**
- Visual Studio
- SQL Server Management Studio
- Git / GitHub

## Архитектура проекта

Проект построен на основе многослойной архитектуры с разделением ответственности между компонентами.

| Проект | Назначение |
|---|---|
| `TaskManager.Api` | HTTP API, контроллеры, DTO, конфигурация приложения |
| `TaskManager.Core` | Доменные сущности, интерфейсы и перечисления |
| `TaskManager.Infrastructure` | EF Core, SQL Server, DbContext, конфигурации и миграции |
| `TaskManager.Client` | Пользовательский интерфейс на React и TypeScript |

**Направление зависимостей:**

- API → Core, Infrastructure
- Infrastructure → Core
- Core не зависит от остальных проектов

## База данных

Для хранения данных используется Microsoft SQL Server.

В Entity Framework Core реализованы девять доменных сущностей:

1. Organization — организации
2. Position — должности сотрудников
3. Role — роли пользователей
4. User — пользователи
5. Project — проекты
6. TaskItem — задачи
7. SubTask — подзадачи
8. Comment — комментарии
9. TaskHistory — история изменений задач

Настройка сущностей выполнена с использованием Fluent API.

Реализованы первичные и внешние ключи, навигационные свойства, ограничения обязательности, уникальные индексы и правила удаления связанных записей.

Создана и успешно применена первая миграция `InitialCreate`.

## Текущее состояние разработки

### Этап 1 — Архитектура и доменная модель

**Завершён.**

- Создано многослойное решение `TaskManager.slnx`.
- Настроены проектные зависимости.
- Созданы девять доменных сущностей.
- Подготовлен React + TypeScript клиент.

### Этап 2 — Entity Framework Core и SQL Server

**Основная часть завершена.**

- Установлены необходимые пакеты EF Core.
- Реализован `TaskManagerDbContext`.
- Созданы девять классов Fluent API конфигураций.
- Настроено подключение к SQL Server.
- Создана и применена миграция `InitialCreate`.
- Проверены таблицы и структура базы данных в SSMS.
- Проверено подключение к базе через инструменты EF Core.

Проверка записи и чтения данных через приложение будет выполнена при разработке API.

### Этап 3 — ASP.NET Core Web API

**Следующий этап.**

Планируется реализация контроллеров, DTO, валидации, CRUD-операций, авторизации JWT и разграничения доступа.

### Этап 4 — React и Kanban-доска

**Запланирован.**

Реализация пользовательского интерфейса, страниц проектов и задач, подключения к API и Kanban-доски с перетаскиванием карточек.

## Планируемая функциональность первой версии

- Регистрация и авторизация пользователей.
- Разграничение доступа по ролям.
- Создание и управление проектами.
- Создание, редактирование и назначение задач.
- Управление статусами и сроками выполнения.
- Kanban-доска с Drag-and-Drop.
- Подзадачи и комментарии.
- История изменений задач.
- Хранение данных в SQL Server.

**ИИ-ассистент** предусмотрен концепцией проекта, но его реализация отложена до следующих версий.

## Локальный запуск

### Требования

- .NET SDK 10
- SQL Server / SQL Server Express
- Node.js 22.12+
- pnpm 11.25.0

### Backend

Откройте `TaskManager.slnx` в Visual Studio либо выполните из корня репозитория:

```powershell
dotnet restore TaskManager.slnx
dotnet build TaskManager.slnx
dotnet run --project TaskManager.Api --launch-profile http
```

Тестовый endpoint:

`http://localhost:5218/weatherforecast`

### Настройка SQL Server

Для локальной разработки строку подключения необходимо настроить через User Secrets проекта `TaskManager.Api`.

Пример настройки:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER\\SQLEXPRESS;Database=TaskManagerDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Замените `YOUR_SERVER` на имя собственного SQL Server.

Строки подключения с паролями и API-ключи не должны публиковаться в репозитории.

### Миграции базы данных

Для создания базы по существующим миграциям используйте консоль диспетчера пакетов Visual Studio:

```powershell
Update-Database -Project TaskManager.Infrastructure -StartupProject TaskManager.Api
```

Миграции находятся в `TaskManager.Infrastructure/Data/Migrations`.

### Frontend

В отдельном терминале:

```powershell
cd TaskManager.Client
pnpm install --frozen-lockfile
pnpm dev
```

Адрес клиента при стандартной конфигурации Vite:

`http://localhost:5173`

Vite настроен для проксирования запросов `/api` и `/weatherforecast` к backend.

Проверка TypeScript:

```powershell
pnpm typecheck
```

Сборка клиента:

```powershell
pnpm build
```

## Примечания

- Приложение находится в стадии разработки.
- Рабочие CRUD-операции и пользовательский интерфейс ещё предстоит реализовать.
- SQL-скрипт в `Data/Scripts` сохранён как вспомогательный материал.
- Основным способом управления структурой базы данных являются миграции EF Core.
- Локальная база SQL Server не включается в репозиторий.
