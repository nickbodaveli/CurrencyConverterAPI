using CurrencyConverter.Application.Converter.Common;
using ErrorOr;
using MediatR;

namespace CurrencyConverter.Application.Converter.Queries
{
    public record ConverterQuery(
        string PrivateNumber
    ) : IRequest<ErrorOr<CountedResult>>;
           
}
