using CurrencyConverter.Application.Converter.Common;
using ErrorOr;
using MediatR;

namespace CurrencyConverter.Application.Converter.Commands.Setter
{
    public record CurrencySetterCommand
      (
        string SetCurrencyCode,
        double SetCurrencyPrice,
        double SetSellPrice
      ) : IRequest<ErrorOr<SetterResult>>;
}
