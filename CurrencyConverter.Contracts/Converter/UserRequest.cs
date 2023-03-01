namespace CurrencyConverter.Contracts.Converter
{
    public record UserRequest
    (
        string PrivateNumber,
        string Name,
        string LastName,
        string RecomendatorPrivateNumber
    );
}
