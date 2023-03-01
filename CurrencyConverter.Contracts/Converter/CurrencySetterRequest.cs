namespace CurrencyConverter.Contracts.Converter
{
    public record CurrencySetterRequest 
        (
            string SetCurrencyCode,
            double SetCurrencyPrice,
            double SetSellPrice
        );
}
