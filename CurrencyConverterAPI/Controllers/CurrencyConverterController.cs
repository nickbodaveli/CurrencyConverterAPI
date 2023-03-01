using CurrencyConverter.Application.Common.Interfaces.Persistence;
using CurrencyConverter.Application.Converter.Commands.Converter;
using CurrencyConverter.Application.Converter.Commands.Register;
using CurrencyConverter.Application.Converter.Commands.Setter;
using CurrencyConverter.Application.Converter.Common;
using CurrencyConverter.Application.Converter.Queries;
using CurrencyConverter.Contracts.Converter;
using CurrencyConverter.Domain.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CurrencyConverterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyConverterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;
        private readonly ICurrencyConverterRepository _currencyConverterRepository;

        public CurrencyConverterController(ISender mediator, IMapper mapper, ICurrencyConverterRepository currencyConverterRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _currencyConverterRepository = currencyConverterRepository;
        }

        [HttpPost("CountedResult")]
        public async Task<IActionResult> CountedResult(CurrencyResultRequest request)
        {
            var query = _mapper.Map<ConverterQuery>(request);

            var result = await _mediator.Send(query);

            if (result.IsError && result.FirstError == ConvertErrors.Errors.PrivateNumberError)
            {
                return Problem(statusCode: StatusCodes.Status400BadRequest, title: result.FirstError.Description);
            }

            return Ok(result.Value);
        }

        [HttpPost("RegisterCurrency")]
        public async Task<IActionResult> RegisterCurrency(RegisterCurrencyRequest request)
        {
            var command = _mapper.Map<CurrencyRegisterCommand>(request);

            var result = await _mediator.Send(command);

            if (result.IsError && result.FirstError == ConvertErrors.Errors.RegisterFieldsError)
            {
                return Problem(statusCode: StatusCodes.Status400BadRequest, title: result.FirstError.Description);
            }

            if(result.Value.isCreated == true)
            {
                return Ok(result.Value);
            }

            return Problem("Currency Already Exists.");
        }

        [HttpPost("SetterCurrency")]
        public async Task<IActionResult> SetterCurrency(CurrencySetterRequest request)
        {
            var command = _mapper.Map<CurrencySetterCommand>(request);

            var result = await _mediator.Send(command);

            if (result.IsError && result.FirstError == ConvertErrors.Errors.CurrencyExistsError)
            {
                return Problem(statusCode: StatusCodes.Status400BadRequest, title: result.FirstError.Description);
            }

            if (result.Value.isCreated == true)
            {
                return Ok(result.Value);
            }

            return Problem("Currency Dosn't Exists.");
        }

        [HttpPost("ConvertCurrencies")]
        public async Task<IActionResult> ConvertCurrencies(ConvertDataRequest request)
        {
            var command = _mapper.Map<ConvertDataCommand>(request);

            var result = await _mediator.Send(command);

            if (result.IsError && result.FirstError == ConvertErrors.Errors.CurrencyExistsError)
            {
                return Problem(statusCode: StatusCodes.Status400BadRequest, title: result.FirstError.Description);
            }

            if (result.Value != null)
            {
                return Ok(result.Value);
            }

            return Problem("Currencies Doesn't Exists.");
        }
    }
}
