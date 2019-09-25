use master
go
if DB_ID (N'Company') is null
create database Company
go
use [Company]
if OBJECT_ID ('ProgressEmployees','U') is not null
drop table ProgressEmployees
go
create table ProgressEmployees
(ProgressEmployeeId int IDENTITY(1,1) not null primary key, FullName nvarchar(20), Progress nvarchar(50), EmployeeId int,
CONSTRAINT FK_ProgressEmployees_To_Employees FOREIGN KEY (EmployeeId)  REFERENCES Employees (EmployeeId));
go