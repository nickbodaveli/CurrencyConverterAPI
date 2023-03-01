using CurrencyConverter.Domain.Common.Models;

namespace CurrencyConverter.Domain
{
    public sealed class UserHistory : AggregateRoot
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PrivateNumber { get; set; }
        public string RecomendatorPrivateNumber { get; set; }
        public double ConvertedPrice { get; set; }
        public DateTime ConvertedTime { get; set; }
        public UserHistoryReport UserHistoryReport { get; set; }

        private UserHistory(
            int userId,
            string privateNumber,
            string recomendatorPrivateNumber,
            double convertertedPrice)
        {
            UserId = userId;
            PrivateNumber = privateNumber;
            RecomendatorPrivateNumber = recomendatorPrivateNumber;
            ConvertedPrice = convertertedPrice;
        }

        public static UserHistory Create(
           int userId,
            string privateNumber,
            string recomendatorPrivateNumber,
            double convertertedPrice)
        {
            return new UserHistory(
                userId,
                privateNumber,
                recomendatorPrivateNumber,
                convertertedPrice);
        }

        private UserHistory()
        {

        }
    }
}
