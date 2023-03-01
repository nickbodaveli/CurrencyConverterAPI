using CurrencyConverter.Domain.Common.Models;

namespace CurrencyConverter.Domain
{
    public sealed class Currency : AggregateRoot
    {
        public int Id { get; set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string NameLatin { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Currency(
            string code,
            string name,
            string nameLatin)
        {
            Code = code;
            Name = name;
            NameLatin = nameLatin;
        }

        public static Currency Create(
            string code,
            string name,
            string nameLatin)
        {
            return new Currency(
                code,
                name,
                nameLatin);
        }

        private Currency()
        {

        }
    }
}
