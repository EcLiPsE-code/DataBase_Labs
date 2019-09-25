--тадлица Employees находится на стороне отношений "МНОГИЕ"
use Company
go
DELETE FROM dbo.Employees
DBCC CHECKIDENT ('Employees', RESEED, 0)
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
		@Age int,
		@Solution money,
		@Profit money,
		@UnitId int

SET @AmountOfData =20000

SELECT @i=1


-- Заполнение данными таблицы Employees
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

		SET @Solution = 1000 + RAND()*1500
		SET @Profit = 2000 + RAND()*1000
		SET @UnitId = CAST((1+RAND()*(500-1)) as int)
		SET @Age = 20 + RAND()*30;

		INSERT INTO dbo.Employees(FullName, Solution, Profit, Age, UnitId) 
		SELECT @FullName, @Solution, @Profit, @Age, @UnitId
		

		SET @RowCount +=1
	END

	SELECT * FROM dbo.Employees