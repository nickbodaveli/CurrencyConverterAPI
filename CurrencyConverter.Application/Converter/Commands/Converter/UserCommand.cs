namespace CurrencyConverter.Application.Converter.Commands.Converter
{
    public record UserCommand
    (
        string PrivateNumber,
        string Name,
        string LastName,
        string RecomendatorPrivateNumber
    );
}
