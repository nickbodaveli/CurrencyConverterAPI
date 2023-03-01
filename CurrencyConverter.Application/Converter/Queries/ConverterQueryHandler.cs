using CurrencyConverter.Application.Common.Interfaces.Persistence;
using CurrencyConverter.Application.Converter.Commands.Setter;
using CurrencyConverter.Application.Converter.Common;
using CurrencyConverter.Domain.Errors;
using ErrorOr;
using MediatR;

namespace CurrencyConverter.Application.Converter.Queries
{
    public class ConverterQueryHandler : IRequestHandler<ConverterQuery, ErrorOr<CountedResult>>
    {
        private readonly ICurrencyConverterRepository _currencyConverterRepository;

        public ConverterQueryHandler(ICurrencyConverterRepository currencyConverterRepository)
        {
            _currencyConverterRepository = currencyConverterRepository;
        }

        public async Task<ErrorOr<CountedResult>> Handle(ConverterQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if(request.PrivateNumber == "") 
                return new[] { ConvertErrors.Errors.PrivateNumberError };

            return _currencyConverterRepository.CountedResult(request);
            
        }
    }
}
