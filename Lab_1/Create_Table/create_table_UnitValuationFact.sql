use master
go
if DB_ID (N'Company') is null
create database Company
go
use [Company]
if OBJECT_ID ('UnitsValuationFact','U') is not null
drop table UnitsValuationFact
go
create table UnitsValuationFact
(UnitValuationFactId int IDENTITY(1,1) not null primary key, FullName nvarchar(20), Income money, Cost money
,UnitId int,CONSTRAINT FK_UnitsValuationFact_To_Units FOREIGN KEY (UnitId)  REFERENCES Units (UnitId) ON DELETE CASCADE
ON UPDATE CASCADE);
