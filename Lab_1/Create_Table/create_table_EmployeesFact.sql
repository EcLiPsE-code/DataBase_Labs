use master
go
if DB_ID (N'Company') is null
create database Company
go
use [Company]
if OBJECT_ID ('EmployeeFact','U') is not null
drop table EmployeeFact
go
create table EmployeeFact
(EmployeeFactId int IDENTITY(1,1) not null primary key, FullName nvarchar(20), Quarter int, Year int, EmployeeId int, ProfitYear money, ProfitQuarter money,
CONSTRAINT FK_EmployeeFact_To_Employees FOREIGN KEY (EmployeeId)  REFERENCES Employees (EmployeeId));
go