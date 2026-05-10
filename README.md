# Legislative Info System

A data entry web application for managing Ohio legislators and legislation, built with Blazor and .NET 10.

## Stack

- **Frontend:** Blazor Interactive Server
- **Backend:** ASP.NET Core / .NET 10
- **Database:** SQLite via Entity Framework Core 10
- **CSS:** Bootstrap 5

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## Getting Started

1. Clone the repository:
```bash
   git clone https://github.com/B-Richie/LegislativeInfoSystem.git
   cd LegislativeInfoSystem/LegislativeInfoSystem
```

2. Run the application:
```bash
   dotnet run
```

3. Open your browser and navigate to `https://localhost:[port]` as shown in the terminal output.

> The database is created automatically on first run. Seed data is also loaded on first run — no manual setup required.

## Usage

### Legislators
- Navigate to **Add Legislator** to create a new legislator entry (First Name, Last Name, and Hometown are required)
- Navigate to **View Legislators** to see all existing legislator entries

### Legislation
- Navigate to **Add Legislation** to create a new legislation entry (Title and Text are required; Sponsors are optional)
- Navigate to **View Legislation** to see all existing legislation entries with associated sponsors

## Notes

- The SQLite database file (`app.db`) is created in the project root on first run
- To reset the database and seed data, delete `app.db`, `app.db-shm`, and `app.db-wal` and restart the application