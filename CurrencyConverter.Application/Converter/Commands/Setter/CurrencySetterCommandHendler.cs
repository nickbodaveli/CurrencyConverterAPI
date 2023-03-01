using CurrencyConverter.Application.Common.Interfaces.Persistence;
using CurrencyConverter.Application.Converter.Common;
using CurrencyConverter.Domain.Errors;
using ErrorOr;
using MediatR;

namespace CurrencyConverter.Application.Converter.Commands.Setter
{
    public class CurrencySetterCommandHendler : IRequestHandler<CurrencySetterCommand, ErrorOr<SetterResult>>
    {
        private readonly ICurrencyConverterRepository _currencyConverterRepository;

        public CurrencySetterCommandHendler(ICurrencyConverterRepository currencyConverterRepository)
        {
            _currencyConverterRepository = currencyConverterRepository;
        }
        public async Task<ErrorOr<SetterResult>> Handle(CurrencySetterCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (request == null)
                return new[] { ConvertErrors.Errors.CurrencyExistsError };

            return _currencyConverterRepository.SetCurrency(request);
        }
    }
}
