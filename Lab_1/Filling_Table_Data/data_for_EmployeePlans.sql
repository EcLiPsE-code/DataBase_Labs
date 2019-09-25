use Company
go
DELETE FROM dbo.EmployeePlans
DBCC CHECKIDENT ('EmployeePlans', RESEED, 0)
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
		@EmployeeFactId int

SET @AmountOfData =20000


SELECT @i=1


-- Заполнение данными таблицы EmployeePlans
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

		SET @Year = CAST((DATEPART(YEAR, GETDATE() - RAND()*2000)) as int) 
		SET @Quarter = CAST((DATEPART(QUARTER, GETDATE() - RAND()*3000)) as int) 
		SET @ProfitQuarter = 8000 + RAND()*8000
		SET @ProfitYear = 17000 + RAND()*17000
		SET @EmployeeFactId = 1 + RAND()*(20000-1)

		INSERT INTO dbo.EmployeePlans(FullName, Quarter, Year, ProfitYear, ProfitQuarter, EmployeeFactId) 
		SELECT @FullName,@Quarter, @Year, @ProfitYear, @ProfitQuarter, @EmployeeFactId
		

		SET @RowCount +=1
	END

	SELECT * FROM dbo.EmployeePlans