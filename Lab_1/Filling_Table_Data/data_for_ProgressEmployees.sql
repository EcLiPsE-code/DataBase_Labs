use Company
go
DELETE FROM dbo.ProgressEmployees
DBCC CHECKIDENT ('ProgressEmployees', RESEED, 0)
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
		@Progress nvarchar(50),
		@EmployeeId int

SET @AmountOfData =20000

SELECT @i=1


-- Заполнение данными таблицы ProgressEmployees
	SET @RowCount=1
	SET @MinNumberSymbols=5
	SET @MaxNumberSymbols=50

	WHILE @RowCount<=@AmountOfData
	BEGIN		

		SET @NameLimit=@MinNumberSymbols+RAND()*(@MaxNumberSymbols-@MinNumberSymbols) -- имя от 5 до 50 символов
		SET @i=1
        SET @FullName=''
		SET @Progress=''

		WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @FullName = @FullName + SUBSTRING(@Symbol, @Position, 1)
			SET @i=@i+1
		END

		SET @i=1
		WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @Progress = @Progress + SUBSTRING(@Symbol, @Position, 1)
			SET @i=@i+1
		END

		SET @EmployeeId = 1 + RAND()*(20000-1)

		INSERT INTO dbo.ProgressEmployees(FullName, Progress, EmployeeId) 
		SELECT @FullName,@Progress, @EmployeeId
		

		SET @RowCount +=1
	END

	SELECT * FROM dbo.ProgressEmployees