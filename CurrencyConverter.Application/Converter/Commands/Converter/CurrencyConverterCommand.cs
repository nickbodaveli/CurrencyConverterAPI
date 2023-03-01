using MediatR;

namespace CurrencyConverter.Application.Converter.Commands.Converter
{
    public record CurrencyConverterCommand
    (
        string Code,
        string Name,
        string NameLatin
    ) : IRequest;
}
