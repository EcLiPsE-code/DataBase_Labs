use master
go
if DB_ID (N'Company') is null
create database Company
go
use [Company]
if OBJECT_ID ('UnitsValuationPlans','U') is not null
drop table UnitsValuationPlans
go
create table UnitsValuationPlans
(UnitValuationPlanId int IDENTITY(1,1) not null primary key, FullName nvarchar(20),Income money, Cost money,
UnitValuationFactId int, CONSTRAINT FK_UnitsValuationPlans_To_UnitsValuationFact FOREIGN KEY (UnitValuationFactId)  REFERENCES UnitsValuationFact (UnitValuationFactId) ON DELETE CASCADE
ON UPDATE CASCADE);
go