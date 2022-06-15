CREATE TRIGGER TR_Salary_Insert ON [dbo].[Salary]
	AFTER INSERT
AS 
begin
	begin try
		begin transaction

			declare @userId nvarchar(50);
			declare @salaryAmount decimal;
			declare @salaryAmountInUserCurrency decimal;
			declare @currencyCode int;
			declare @userCurrency int;
			declare @currencyBalanceId uniqueidentifier;
			declare @exchangeRate float;
			declare @rowsFound int = 0;

			select
				@userId = UserId,
				@salaryAmount = Amount,
				@currencyCode = Currency
			from inserted;

			select
				@userCurrency = users.MainCurrency,
				@currencyBalanceId = balances.Id
			from
				dbo.AspNetUsers as users
				left join dbo.CurrencyBalance as balances
				on balances.UserId = users.Id
			where users.Id = @userId and balances.Currency = @currencyCode;

			select @rowsFound = count(*)
			from dbo.BaseCurrencyRate
			where
				UserId = @userId
				and ToCurrency = @userCurrency
				and FromCurrency = @currencyCode

			if @rowsFound = 0
			begin
				select @exchangeRate = Rate
				from dbo.BaseCurrencyRate
				where FromCurrency = @currencyCode and ToCurrency = @userCurrency
			end
			else
			begin
				select @exchangeRate = Rate
				from dbo.BaseCurrencyRate
				where UserId = @userId
				and ToCurrency = @userCurrency
				and FromCurrency = @currencyCode
			end

			print(@exchangeRate)
			print('user id: ' + cast(@userId as nvarchar(50)))
			print('currency balance id: ' + cast(@currencyBalanceId as nvarchar(50)))

			update dbo.AspNetUsers set Amount = Amount + (@salaryAmount * @exchangeRate)
			where Id = @userId;

			update dbo.CurrencyBalance set Amount = Amount + @salaryAmount
			where Id = @currencyBalanceId;

		commit transaction
	end try
	begin catch
		IF (@@TRANCOUNT > 0)
		BEGIN
			ROLLBACK TRANSACTION
			PRINT 'Error detected, all changes reversed'
		END
	end catch
end
GO


