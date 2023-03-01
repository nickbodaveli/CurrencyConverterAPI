using CurrencyConverter.Domain.Common.Models;

namespace CurrencyConverter.Domain
{
    public sealed class UserHistoryReport : AggregateRoot
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserHistoryId { get; set; }
        public double ConvertedPriceSumOfGel { get; set; }
        public double ConvertedPriceSum { get; set; }
        public DateTime ConvertedDate { get; set; }

        //public UserHistory UserHistory { get; set; }

        private UserHistoryReport(
            int userId,
            int userHistoryId,
            double convertedPriceSumOfGel,
            double convertedPriceSum)
        {
            UserId = userId;
            UserHistoryId = userHistoryId;
            ConvertedPriceSumOfGel = convertedPriceSumOfGel;
            ConvertedPriceSum = convertedPriceSum;
        }

        public static UserHistoryReport Create(
            int userId,
            int userHistoryId,
            double convertedPriceSumOfGel,
            double convertedPriceSum)
        {
            return new UserHistoryReport(
                userId,
                userHistoryId,
                convertedPriceSumOfGel,
                convertedPriceSum);
        }

        private UserHistoryReport()
        {

        }
    }
}
