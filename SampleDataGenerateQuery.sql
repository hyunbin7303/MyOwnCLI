



DECLARE @randomDate datetime
Declare @randomDate2 datetime2
Declare @fromDate datetime= '2020-01-01'
Declare @toDate datetime = CURRENT_TIMESTAMP

Declare @Id int
SET @Id = 0;

while @Id <= 1000
BEGIN

	SELECT @randomDate = 
	(DATEADD(day, Round(DateDiff(day, @fromDate, @toDate) * RAND(CHECKSUM(NewID())),5),
	DateAdd(second,abs(Checksum(newID()))%86400,@fromDate)))

		INSERT INTO SampleTable
		VALUES (@Id, CONVERT(varchar(50),newID()), @randomDate,@randomDate, CONVERT(varchar(50), newid()))
		SET @Id = @Id+1;
END

select * from SampleTable