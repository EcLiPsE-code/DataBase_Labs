--таблица Units находится на стороне отношений "ОДИН"
use Company
go
DELETE FROM Units
DBCC CHECKIDENT ('Units', RESEED, 0)
go
DECLARE @Symbol CHAR(52)= 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',
		@Position int,
		@i int,
		@NameLimit int,
		@FullName nvarchar(20),
		@RowCount INT,
		@MinNumberSymbols int,
		@MaxNumberSymbols int,
		@CountEmployees int,
		@AmountOfData int

SET @AmountOfData = 500

SELECT @i=1


-- Заполнение данными таблицы Units
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

		
		SET @CountEmployees = CAST((50 + RAND()*150) as int)

		INSERT INTO dbo.Units(FullName, CountEmployees) 
		SELECT @FullName, @CountEmployees

		SET @RowCount +=1
	END

	SELECT * FROM dbo.Units