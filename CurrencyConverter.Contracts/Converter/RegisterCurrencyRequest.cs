namespace CurrencyConverter.Contracts.Converter
{
    public record RegisterCurrencyRequest
    (
        string Code,
        string Name,
        string NameLatin
    );
}
