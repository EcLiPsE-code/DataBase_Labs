use master
go
if DB_ID (N'Company') is null
create database Company
go
use [Company]
if OBJECT_ID ('EmployeePlans','U') is not null
drop table EmployeePlans
go
create table EmployeePlans
(EmployeePlanId int IDENTITY(1,1) not null primary key, FullName nvarchar(20), Quarter int, Year int, EmployeeFactId int, ProfitQuarter money, ProfitYear money,
CONSTRAINT FK_EmployeePlans_To_EmployeeFact FOREIGN KEY (EmployeeFactId)  REFERENCES EmployeeFact (EmployeeFactId));
go