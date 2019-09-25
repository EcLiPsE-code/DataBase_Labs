use master
go
if DB_ID (N'Company') is null
create database Company
go
use [Company]
if OBJECT_ID ('Employees','U') is not null
drop table Employees
go
create table Employees
(EmployeeId int IDENTITY(1,1) not null primary key, FullName nvarchar(20), Solution money,Profit money, Age int, UnitId int,
CONSTRAINT FK_Employees_To_Units FOREIGN KEY (UnitId)  REFERENCES Units (UnitId));
go