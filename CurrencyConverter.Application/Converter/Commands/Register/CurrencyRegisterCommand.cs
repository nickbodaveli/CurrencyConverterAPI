using CurrencyConverter.Application.Converter.Common;
using ErrorOr;
using MediatR;

namespace CurrencyConverter.Application.Converter.Commands.Register
{
    public record CurrencyRegisterCommand
     (
        string Code,
        string Name,
        string NameLatin
    ) : IRequest<ErrorOr<RegisterResult>>;
}
