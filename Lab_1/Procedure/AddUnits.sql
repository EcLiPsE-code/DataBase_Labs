use Company
go
drop procedure AddUnits
go
create procedure AddUnits
	@FullName nvarchar(20),
	@CountEmployees int
as
insert into dbo.Units(FullName, CountEmployees)
values (@FullName,@CountEmployees)