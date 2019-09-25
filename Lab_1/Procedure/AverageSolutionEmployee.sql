use Company
go
drop procedure AverageSolutionEmployee
go
create procedure AverageSolutionEmployee
	@averageSolution varchar(20) output,
	@minSolution varchar(20) output,
	@maxSolution varchar(20) output
as
select @averageSolution = AVG(Solution), @minSolution = MIN(Solution), @maxSolution = MAX(Solution)
from dbo.Employees