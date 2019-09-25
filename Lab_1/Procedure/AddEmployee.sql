use Company
go
drop procedure AddEmployee
go
create procedure AddEmployee
	@FullName nvarchar(20),
	@Solution money,
	@Profit money,
	@Age int,
	@UnitId int
as
insert into dbo.Employees(FullName, Solution, Profit, Age, UnitId)
values (@FullName,@Solution,@Profit,@Age,@UnitId)