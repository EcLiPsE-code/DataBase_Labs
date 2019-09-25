use Company
go
declare @minSolution varchar(20), @maxSolution varchar(20), @averageSolution varchar(20)

exec AverageSolutionEmployee @averageSolution output, @minSolution output, @maxSolution output

print 'Average Solution = ' + convert(varchar(20), @averageSolution)
print 'Min Solution = ' + convert(varchar(20), @minSolution)
print 'Max Solution = ' + convert(varchar(20), @maxSolution)