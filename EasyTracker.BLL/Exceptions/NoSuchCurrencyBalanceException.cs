using System.Runtime.Serialization;

namespace EasyTracker.BLL.Exceptions
{
    public class NoSuchCurrencyBalanceException : Exception
    {
        public NoSuchCurrencyBalanceException() : base("You haven't specified currency balance") { }

        public NoSuchCurrencyBalanceException(string currency)
            : base($"You haven't {currency} balance") { }

        public NoSuchCurrencyBalanceException(string currency, Exception innerException)
            : base($"You haven't {currency} balance", innerException) { }
    }
}
