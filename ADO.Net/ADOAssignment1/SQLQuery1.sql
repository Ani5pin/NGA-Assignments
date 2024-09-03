

USE PracticeDb;

CREATE TABLE Student (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    DateOfBirth DATE,
    Marks INT,
    Batch NVARCHAR(50),
    Course NVARCHAR(100)
);
select *  from Student;
