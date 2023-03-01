namespace CurrencyConverter.Contracts.Converter
{
    public record CurrencyDataRequest
    (
        string FromCurrencyCode,
        string ToCurrencyCode,
        double Price
    );
}
