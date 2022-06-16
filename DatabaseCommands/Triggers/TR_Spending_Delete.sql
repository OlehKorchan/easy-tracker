alter TRIGGER [dbo].[TR_Spending_Delete]
	ON [dbo].[Spending]
	after delete
AS
BEGIN
	begin TRY
	begin transaction
	declare @userId nvarchar(50);
	declare @spendingAmount decimal(18, 2);
	declare @spendingCurrency int;
	declare @userCurrency int;
	declare @userCurrencyBalanceId uniqueidentifier;
	declare @categoryId uniqueidentifier;
	declare @rate float;

	select
		@categoryId = SpendingCategoryId,
		@spendingAmount = Amount,
		@spendingCurrency = Currency
	from deleted;

	select
		@userCurrencyBalanceId = balances.Id,
		@userCurrency = users.MainCurrency,
		@userId = users.Id
	from
		dbo.AspNetUsers as users
		left join dbo.SpendingCategory as categories
		on categories.UserId = users.Id
		left join dbo.CurrencyBalance as balances
		on users.Id = balances.UserId and balances.Currency = @spendingCurrency
	where categories.Id = @categoryId

	select @rate = Rate
	from dbo.BaseCurrencyRate
	where
		UserId = @userId
		and FromCurrency = @spendingCurrency
		and ToCurrency = @userCurrency;

	if @rate is null or len(@rate) <= 0
	BEGIN
		select @rate = Rate
		from dbo.BaseCurrencyRate
		where FromCurrency = @spendingCurrency and ToCurrency = @userCurrency
	END

	update dbo.AspNetUsers set Amount = Amount + (@spendingAmount * @rate)
	where Id = @userId;

	update dbo.CurrencyBalance set Amount = Amount + @spendingAmount
	where Id = @userCurrencyBalanceId;

	commit TRANSACTION
	end TRY
	begin CATCH
	IF (@@TRANCOUNT > 0)
	BEGIN
		ROLLBACK TRANSACTION
		PRINT error_message()
	END
	end catch
END
