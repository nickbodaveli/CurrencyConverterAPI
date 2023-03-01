namespace CurrencyConverter.Application.Converter.Common
{
    public record ConvertResult
    (
         string From,
         string To,
         string Course,
         double ConvertedPrice
    );
}
