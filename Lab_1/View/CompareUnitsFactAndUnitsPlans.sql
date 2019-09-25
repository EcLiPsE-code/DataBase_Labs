use Company
go
drop view CompareUnitsFactAndUnitsPlans
go
create view CompareUnitsFactAndUnitsPlans as
select	dbo.UnitsValuationFact.Income as IncomeUnitsFact,
		dbo.UnitsValuationPlans.Income as IncomeUnitsPlans,
		(dbo.UnitsValuationPlans.Income-dbo.UnitsValuationFact.Income) as Different
from dbo.UnitsValuationFact inner join dbo.UnitsValuationPlans on dbo.UnitsValuationFact.UnitValuationFactId = dbo.UnitsValuationPlans.UnitValuationFactId
go

select * from CompareUnitsFactAndUnitsPlans
