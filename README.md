# 🚀 Hangfire Learning Project (.NET)

A simple project to learn how to use **Hangfire** in ASP.NET Core for background job processing.

## 📌 What is Hangfire?

Hangfire is an open-source library that allows you to run background jobs in .NET applications.

It supports:

- Fire-and-forget jobs
- Delayed jobs
- Recurring jobs (Cron)
- Job continuations
- Background processing
- Dashboard for monitoring jobs

---

# 🛠 Technologies

- ASP.NET Core (.NET)
- Hangfire
- SQL Server
- Entity Framework Core

---

# 📦 NuGet Packages

Install the required packages:

```bash
dotnet add package Hangfire.AspNetCore
dotnet add package Hangfire.SqlServer
```

Or from NuGet Package Manager:

- Hangfire.AspNetCore
- Hangfire.SqlServer

---

# ⚙️ Configuration

Register Hangfire in `Program.cs`

```csharp
using Hangfire;
using Hangfire.SqlServer;

builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddHangfireServer();
```

Enable the dashboard:

```csharp
var app = builder.Build();

app.UseHangfireDashboard();

app.Run();
```

---

# 🗄 Connection String

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=HangfireDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

When the application starts, Hangfire automatically creates the required tables.

---

# 📊 Hangfire Dashboard

Open your browser:

```
https://localhost:{PORT}/hangfire
```

From the dashboard you can:

- View jobs
- Retry failed jobs
- Delete jobs
- Monitor workers
- View processing history

---

# 📚 Types of Jobs

## 1️⃣ Fire-and-Forget

Runs only once immediately.

```csharp
BackgroundJob.Enqueue(() =>
    Console.WriteLine("Hello Hangfire"));
```

---

## 2️⃣ Delayed Job

Runs after a specified delay.

```csharp
BackgroundJob.Schedule(
    () => Console.WriteLine("Executed later"),
    TimeSpan.FromMinutes(5));
```

---

## 3️⃣ Recurring Job

Runs repeatedly based on a Cron expression.

```csharp
RecurringJob.AddOrUpdate(
    "DailyJob",
    () => Console.WriteLine("Running every day"),
    Cron.Daily);
```

Examples:

```csharp
Cron.Minutely
Cron.Hourly
Cron.Daily
Cron.Weekly
Cron.Monthly
```

---

## 4️⃣ Continuation Job

Runs after another job finishes successfully.

```csharp
var jobId = BackgroundJob.Enqueue(() =>
    Console.WriteLine("First Job"));

BackgroundJob.ContinueJobWith(jobId, () =>
    Console.WriteLine("Second Job"));
```

---

# 📁 Example Controller

```csharp
using Hangfire;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/jobs")]
public class JobsController : ControllerBase
{
    [HttpPost("fire")]
    public IActionResult Fire()
    {
        BackgroundJob.Enqueue(() => Console.WriteLine("Fire Job"));

        return Ok("Fire-and-Forget Job Created");
    }

    [HttpPost("delay")]
    public IActionResult Delay()
    {
        BackgroundJob.Schedule(
            () => Console.WriteLine("Delayed Job"),
            TimeSpan.FromMinutes(1));

        return Ok("Delayed Job Scheduled");
    }

    [HttpPost("recurring")]
    public IActionResult Recurring()
    {
        RecurringJob.AddOrUpdate(
            "hello-job",
            () => Console.WriteLine("Recurring Job"),
            Cron.Minutely);

        return Ok("Recurring Job Added");
    }

    [HttpPost("continue")]
    public IActionResult Continue()
    {
        var id = BackgroundJob.Enqueue(() =>
            Console.WriteLine("First Job"));

        BackgroundJob.ContinueJobWith(id, () =>
            Console.WriteLine("Second Job"));

        return Ok("Continuation Job Created");
    }
}
```

---

# 📖 Cron Cheat Sheet

| Expression | Description |
|------------|-------------|
| `Cron.Minutely` | Every minute |
| `Cron.Hourly` | Every hour |
| `Cron.Daily` | Every day |
| `Cron.Weekly` | Every week |
| `Cron.Monthly` | Every month |
| `Cron.Yearly` | Every year |

---

# 📂 Project Structure

```
HangfireLearning
│
├── Controllers
│   └── JobsController.cs
│
├── Program.cs
│
├── appsettings.json
│
└── README.md
```

---

# ▶️ Running the Project

1. Clone the repository

```bash
git clone https://github.com/your-username/HangfireLearning.git
```

2. Navigate to the project

```bash
cd HangfireLearning
```

3. Restore packages

```bash
dotnet restore
```

4. Run the application

```bash
dotnet run
```

5. Open the dashboard

```
https://localhost:{PORT}/hangfire
```

---

# 🎯 Learning Objectives

After completing this project, you should understand:

- ✅ What Hangfire is
- ✅ Background job processing
- ✅ Fire-and-forget jobs
- ✅ Delayed jobs
- ✅ Recurring jobs
- ✅ Continuation jobs
- ✅ Hangfire Dashboard
- ✅ SQL Server storage
- ✅ Basic Hangfire configuration

---

# 📚 Useful Resources

- Official Documentation: https://docs.hangfire.io/
- GitHub Repository: https://github.com/HangfireIO/Hangfire

---

## ⭐ If this project helped you learn Hangfire, consider giving it a star!
