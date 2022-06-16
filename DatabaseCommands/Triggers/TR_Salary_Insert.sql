ALTER TRIGGER TR_Salary_Insert ON [dbo].[Salary]
	AFTER INSERT
AS
begin
	begin try
	begin transaction

	declare @userId nvarchar(50);
	declare @salaryAmount decimal(18,2);
	declare @salaryAmountInUserCurrency decimal(18,2);
	declare @salaryCurrency int;
	declare @userCurrency int;
	declare @currencyBalanceId uniqueidentifier;
	declare @exchangeRate float;

	select
		@userId = UserId,
		@salaryAmount = Amount,
		@salaryCurrency = Currency
	from inserted;

	select
		@userCurrency = users.MainCurrency,
		@currencyBalanceId = balances.Id
	from
		dbo.AspNetUsers as users
		left join dbo.CurrencyBalance as balances
		on balances.UserId = users.Id and balances.Currency = @salaryCurrency
	where users.Id = @userId;

	select @exchangeRate = Rate
	from dbo.BaseCurrencyRate
	where UserId = @userId
		and ToCurrency = @userCurrency
		and FromCurrency = @salaryCurrency

	if @exchangeRate is null or len(@exchangeRate) <= 0
	begin
		select @exchangeRate = Rate
		from dbo.BaseCurrencyRate
		where FromCurrency = @salaryCurrency and ToCurrency = @userCurrency
	end

	update dbo.AspNetUsers set Amount = Amount + (@salaryAmount * @exchangeRate)
	where Id = @userId;

	if (@currencyBalanceId IS NULL)
		OR (LEN(@currencyBalanceId) <= 0)
	BEGIN
		insert into dbo.CurrencyBalance
			(Id, Amount, UserId, Currency)
		VALUES(NEWID(), @salaryAmount, @userId, @salaryCurrency)
	END
	else
	begin
		update dbo.CurrencyBalance set Amount = Amount + @salaryAmount
		where Id = @currencyBalanceId;
	end

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


