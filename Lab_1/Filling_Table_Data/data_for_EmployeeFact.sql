--таблица EmployeeFact находится на стороне отношений "МНОГИЕ"
use Company
go
DELETE FROM dbo.EmployeeFact
DBCC CHECKIDENT ('EmployeeFact', RESEED, 0)
go
DECLARE @Symbol CHAR(52)= 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',
		@Position int,
		@i int,
		@NameLimit int,
		@FullName nvarchar(20),
		@RowCount INT,
		@MinNumberSymbols int,
		@MaxNumberSymbols int,
		@AmountOfData int,
		@Quarter int,
		@Year int,
		@ProfitYear money,
		@ProfitQuarter money,
		@EmployeeId int


SET @AmountOfData = 20000

SELECT @i=1 

-- Заполнение данными таблицы EmployeeFact
	SET @RowCount=1
	SET @MinNumberSymbols=5
	SET @MaxNumberSymbols=50

	WHILE @RowCount<=@AmountOfData
	BEGIN		
		
		SET @NameLimit=@MinNumberSymbols+RAND()*(@MaxNumberSymbols-@MinNumberSymbols) -- имя от 5 до 50 символов
		SET @i=1
        SET @FullName=''

		WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @FullName = @FullName + SUBSTRING(@Symbol, @Position, 1)
			SET @i=@i+1
		END

		
		SET @Year = CAST((DATEPART(YEAR, GETDATE() - RAND()*3000)) as int) 
		SET @Quarter = CAST((DATEPART(QUARTER, GETDATE() - RAND()*3000)) as int) 
		SET @ProfitQuarter = 3000 + RAND()*3000
		SET @ProfitYear = 12000 + RAND()*12000
		SET @EmployeeId = 1 + RAND()*(2000-1)

		INSERT INTO dbo.EmployeeFact(FullName, Quarter, Year,EmployeeId, ProfitYear, ProfitQuarter) 
		SELECT @FullName, @Quarter, @Year, @EmployeeId, @ProfitYear, @ProfitQuarter
		

		SET @RowCount +=1
	END

	SELECT * FROM dbo.EmployeeFact