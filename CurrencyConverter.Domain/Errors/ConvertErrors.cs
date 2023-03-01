using ErrorOr;

namespace CurrencyConverter.Domain.Errors
{
    public static class ConvertErrors
    {
        public static class Errors
        {
            public static Error PrivateNumberError => Error.Validation(
            code: "PrivateNumber Cannot Be Empty",
            description: "Invalid PrivateNumber.");

            public static Error RegisterFieldsError => Error.Validation(
            code: "Register Fields Cannot Be Empty",
            description: "Invalid Credentials.");

            public static Error CurrencyExistsError => Error.Validation(
               code: "Currency Doesn't Exists.",
               description: "Invalid Credentials.");

            public static Error ConvertingCurrenciesExists => Error.Validation(
              code: "Converting Currencies Doesn't Exists.",
              description: "Invalid Credentials.");
        }
    }
}
