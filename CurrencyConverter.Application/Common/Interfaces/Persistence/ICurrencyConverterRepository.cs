using CurrencyConverter.Application.Converter.Commands.Converter;
using CurrencyConverter.Application.Converter.Commands.Register;
using CurrencyConverter.Application.Converter.Commands.Setter;
using CurrencyConverter.Application.Converter.Common;
using CurrencyConverter.Application.Converter.Queries;

namespace CurrencyConverter.Application.Common.Interfaces.Persistence
{
    public interface ICurrencyConverterRepository
    {
        CountedResult? CountedResult(ConverterQuery request);
        RegisterResult RegisterCurrency(CurrencyRegisterCommand request);
        SetterResult SetCurrency(CurrencySetterCommand request);
        ConvertResult? ConvertCurrency(ConvertDataCommand request);
    }
}
