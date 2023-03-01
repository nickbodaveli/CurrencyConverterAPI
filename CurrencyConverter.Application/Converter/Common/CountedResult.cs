namespace CurrencyConverter.Application.Converter.Common
{
    public record CountedResult
    (
         string PrivateNumber,
         int CountedCurrency,
         int CountedCurrencyByRecomendator 
    );
}
