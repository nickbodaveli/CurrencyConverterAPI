using CurrencyConverter.Application.Common.Interfaces.Persistence;
using CurrencyConverter.Application.Converter.Common;
using CurrencyConverter.Domain.Errors;
using ErrorOr;
using MediatR;

namespace CurrencyConverter.Application.Converter.Commands.Register
{
    public class CurrencyRegisterCommandHandler : IRequestHandler<CurrencyRegisterCommand, ErrorOr<RegisterResult>>
    {
        private readonly ICurrencyConverterRepository _currencyConverterRepository;

        public CurrencyRegisterCommandHandler(ICurrencyConverterRepository currencyConverterRepository)
        {
            _currencyConverterRepository = currencyConverterRepository;
        }

        public async Task<ErrorOr<RegisterResult>> Handle(CurrencyRegisterCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (request == null)
                return new[] { ConvertErrors.Errors.RegisterFieldsError };

            return _currencyConverterRepository.RegisterCurrency(request);
        }
    }
}
