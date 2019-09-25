use Company
go
drop view CompareEmployeeFactAndEmployeePlans
go
create view CompareEmployeeFactAndEmployeePlans as
select	dbo.EmployeeFact.Year as YearEmployeeFact,
		dbo.EmployeeFact.ProfitYear as ProfitYearEmployeeFact,
		dbo.EmployeePlans.Year as YearEmployeePlans,
		dbo.EmployeePlans.ProfitYear as ProfitYearEmployeePlans,
		(dbo.EmployeePlans.ProfitYear - dbo.EmployeeFact.ProfitYear) as Different
from dbo.EmployeeFact inner join dbo.EmployeePlans on dbo.EmployeeFact.EmployeeFactId = dbo.EmployeePlans.EmployeePlanId
go

select * from CompareEmployeeFactAndEmployeePlans
