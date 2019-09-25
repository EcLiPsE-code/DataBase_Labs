use Company
go
drop view EmployeesAndTheirProgress
go
create view EmployeesAndTheirProgress as
select	dbo.ProgressEmployees.Progress as Progress,
		dbo.Employees.FullName as Name,
		dbo.Employees.Age as Age
from Employees inner join ProgressEmployees on dbo.Employees.EmployeeId = dbo.ProgressEmployees.EmployeeId
go

select * from EmployeesAndTheirProgress
