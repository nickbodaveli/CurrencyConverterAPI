namespace CurrencyConverter.Contracts.Converter
{
    public record CountedResponse
    (
         string PrivateNumber,
         int CountedCurrency,
         int CountedCurrencyByRecomendator
    );
}
