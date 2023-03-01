using CurrencyConverter.Application.Converter.Commands.Converter;
using CurrencyConverter.Application.Converter.Commands.Register;
using CurrencyConverter.Application.Converter.Commands.Setter;
using CurrencyConverter.Application.Converter.Queries;
using CurrencyConverter.Contracts.Converter;
using Mapster;

namespace CurrencyConverterAPI.Common.Mapper
{
    public class CurrencyConverterMappingConfig
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterCurrencyRequest, CurrencyRegisterCommand>();
            config.NewConfig<CurrencySetterRequest, CurrencySetterCommand>();
            config.NewConfig<CurrencyDataRequest, CurrencyDataCommand>();
            config.NewConfig<CurrencyResultRequest, ConverterQuery>();
        }
    }
}
