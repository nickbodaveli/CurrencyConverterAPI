namespace CurrencyConverter.Application.Converter.Commands.Converter
{
    public record CurrencyDataCommand
    (
        string FromCurrencyCode,
        string ToCurrencyCode,
        double Price
    );
}
