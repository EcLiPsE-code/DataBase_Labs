use master
go
if DB_ID (N'Company') is null
create database Company
go
use [Company]
if OBJECT_ID ('Units','U') is not null
drop table Units
go
create table Units
(UnitId int IDENTITY(1,1) not null primary key, FullName nvarchar(20),CountEmployees int)
go
