using CurrencyConverter.Application.Common.Interfaces.Persistence;
using CurrencyConverter.Application.Converter.Common;
using CurrencyConverter.Domain.Errors;
using ErrorOr;
using MediatR;

namespace CurrencyConverter.Application.Converter.Commands.Converter
{
    public class CurrencyConverterCommandHandler : IRequestHandler<ConvertDataCommand, ErrorOr<ConvertResult>>
    {
        private readonly ICurrencyConverterRepository _currencyConverterRepository;

        public CurrencyConverterCommandHandler(ICurrencyConverterRepository currencyConverterRepository)
        {
            _currencyConverterRepository = currencyConverterRepository;
        }

        public async Task<ErrorOr<ConvertResult>> Handle(ConvertDataCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (request == null)
                return new[] { ConvertErrors.Errors.ConvertingCurrenciesExists };

            return _currencyConverterRepository.ConvertCurrency(request);
        }
    }
}
