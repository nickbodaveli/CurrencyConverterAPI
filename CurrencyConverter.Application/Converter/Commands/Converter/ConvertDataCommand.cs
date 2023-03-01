using CurrencyConverter.Application.Converter.Common;
using ErrorOr;
using MediatR;

namespace CurrencyConverter.Application.Converter.Commands.Converter
{
    public record ConvertDataCommand
    (
        UserCommand User,
        CurrencyDataCommand ConvertCurrencies
    ) : IRequest<ErrorOr<ConvertResult>>;
}
