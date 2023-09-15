# Employee_Jobs

## About
The "Employee_Jobs" project is a web application that allows users to manage jobs and employees, facilitating the assignment of jobs to employees. This application provides features for creating, editing, deleting, and restoring jobs and employees.

## Key Features
- **Jobs Management:**
  - Create, edit, delete, and restore jobs.
  - Categorize jobs by name and category.
  - Prevent job deletion if it has assigned employees.
  - filtering my job name.

- **Employee Management:**
  - Create, edit, delete, and restore employees.
  - Assign multiple jobs to employees.
  - Prevent employee deletion if it has assigned jobs.
  - filtering by employee name and job name. 

## Technologies Used
- ASP.NET Core 6.0
- Entity Framework Core 
- C# 
- HTML/CSS
- JavaScript
- Bootstrap

## Getting Started

### Prerequisites

Before you begin, make sure you have the following prerequisites installed on your system:

- [Visual Studio](https://visualstudio.microsoft.com/downloads/)
- [.NET SDK](https://dotnet.microsoft.com/download)

### Installation
To run this project locally, follow these steps:
1. Clone the repository:
   ```bash
   git clone https://github.com/mesto53/Employees_Jobs.git
2. Update your Connection String in appsettings.json:
   ```bash
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\SQLLocalDB;Database=YourDatabase;Integrated Security=True"
      },
   }

   replace [SQLLocalDB] with your local name and [YourDatabase] with your database name. 


3. Open Console: 
   ```bash
   open tools->nuget pachage manager ->package manager console 

4. Run Database Migration Scripts:
   ```bash
    -add-migration yourcomment
    -update-database
   
   Replace yourcomment with a brief description of the migration.


## Contact :
Mohammad Almestrah - [mhmdmestrah53@gmail.com]

Project Link: https://github.com/mesto53/Employees_Jobs.git
