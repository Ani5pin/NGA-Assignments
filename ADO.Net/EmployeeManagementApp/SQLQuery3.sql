create database EmployeeDb;
use EmployeeDb;

CREATE TABLE Employee (
    ID INT PRIMARY KEY,
    Name NVARCHAR(100),
    DateOfBirth DATE NOT NULL,
    DateOfJoining DATE NOT NULL,
    Salary DECIMAL(18, 2) NULL,
    Dept NVARCHAR(10) CHECK (Dept IN ('HR', 'Accts', 'IT')),
    Password NVARCHAR(100) NOT NULL -- Store hashed password
);

select * from Employee;
