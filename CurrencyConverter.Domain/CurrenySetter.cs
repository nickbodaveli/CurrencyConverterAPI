using CurrencyConverter.Domain.Common.Models;

namespace CurrencyConverter.Domain
{
    public sealed class CurrencySetter : AggregateRoot
    {
        public int Id { get; set; }
        public int? CurrencyId { get; set; }
        public string SetCurrencyCode { get; set; }
        public double SetCurrencyPrice { get; set; }
        public double SetSellPrice { get; set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private CurrencySetter(
            //CurrencyId currencyId,
            int currrencyId,
            string setCurrencyCode,
            double setCurrencyPrice,
            double setSellPrice)
        //DateTime createdDateTime,
        //DateTime updatedDateTime,)

        {
            CurrencyId = currrencyId;
            SetCurrencyCode = setCurrencyCode;
            SetCurrencyPrice = setCurrencyPrice;
            SetSellPrice = setSellPrice;
            //CreatedDateTime = createdDateTime;
            //UpdatedDateTime = updatedDateTime;
        }

        public static CurrencySetter Create(
            int currrencyId,
            string setCurrencyCode,
            double setCurrencyPrice,
            double setSellPrice)
        {
            return new CurrencySetter(
                //CurrencyId.CreateUnique(),
                currrencyId,
                setCurrencyCode,
                setCurrencyPrice,
                setSellPrice);
            //DateTime.UtcNow,
            //DateTime.UtcNow,
        }

        public CurrencySetter()
        {

        }
    }
}
