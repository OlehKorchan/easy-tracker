CREATE TRIGGER TR_User_Insert ON [dbo].[AspNetUsers]
	AFTER INSERT
AS
begin
	begin try
	begin transaction

	declare @userId nvarchar(50);
	declare @userCurrency int;
	declare @fakeAmount decimal(18, 2) = 0;

	select
		@userId = Id, @userCurrency = MainCurrency
	from inserted;

	INSERT INTO SpendingCategory
		(Id, UserId, CategoryName, Description, ImageSrc, PlannedAmount)
	SELECT NEWID(), @userId, CategoryName, Description, ImageSrc, @fakeAmount
	from MainSpendingCategory

	INSERT INTO CurrencyBalance
		(Id, Currency, UserId, Amount)
	VALUES(NEWID(), @userCurrency, @userId, @fakeAmount)


	commit transaction
	end try
	begin catch
		IF (@@TRANCOUNT > 0)
		BEGIN
		ROLLBACK TRANSACTION
		PRINT error_message()
	END
	end catch
end
GO


