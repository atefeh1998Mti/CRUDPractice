# Student CRUD Console Application (C#)

This is a simple console application written in C# that performs **CRUD operations** (Create, Read, Update, Delete) on a `Student` table in SQL Server.

---

## Features

- **Create (Insert):** Add a new student with details (Name, Family, Age, Mark)
- **Read (GetAll):** Display all students from the database
- **Update:** Update the name of a student (can be extended to update all fields)
- **Delete:** Remove a student based on their name

---

## Prerequisites

- Visual Studio or any C# IDE
- SQL Server and access to a database
- `Student` table with the following structure:

```sql
CREATE TABLE Student (
    name NVARCHAR(50),
    family NVARCHAR(50),
    age INT,
    mark INT
);
