--таблица UnitsValuationFact находится на стороне отношений "МНОГИЕ"
use Company
go
DELETE FROM dbo.UnitsValuationFact
DBCC CHECKIDENT ('UnitsValuationFact', RESEED, 0)
go
DECLARE @Symbol CHAR(52)= 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',
		@Position int,
		@i int,
		@NameLimit int,
		@FullName nvarchar(20),
		@Income money,
		@Cost money,
		@RowCount INT,
		@MinNumberSymbols int,
		@MaxNumberSymbols int,
		@AmountOfData int,
		@NumberUnitId int


SET @AmountOfData =20000

SELECT @i=1


-- Заполнение данными таблицы UnitsValuationFact
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

		SET @Income = 100000 + RAND()*100000
		SET @Cost = 50000 + RAND()*50000
		SET @NumberUnitId = 1 + RAND()*(500-1)

		INSERT INTO dbo.UnitsValuationFact(FullName, Income, Cost, UnitId) 
		SELECT @FullName, @Income, @Cost, @NumberUnitId
		

		SET @RowCount +=1
	END

	SELECT * FROM dbo.UnitsValuationFact