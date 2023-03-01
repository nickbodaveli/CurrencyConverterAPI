namespace CurrencyConverter.Contracts.Converter
{
    public record ConvertDataRequest
    (
        UserRequest User,
        CurrencyDataRequest ConvertCurrencies
    );
}
