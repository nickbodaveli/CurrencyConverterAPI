using CurrencyConverter.Domain.Common.Models;

namespace CurrencyConverter.Domain
{
    public sealed class User : AggregateRoot
    {
        private readonly List<UserHistory> _userHistories = new();
        public int Id { get; set; }
        public string PrivateNumber { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
        public IReadOnlyList<UserHistory?> UserHistories => _userHistories.AsReadOnly();
        private User(
            string privateNumber,
            string? name,
            string? lastName)
        {
            PrivateNumber = privateNumber;
            Name = name;
            LastName = lastName;
        }

        private User(
            string privateNumber)
        {
            PrivateNumber = privateNumber;
        }

        public static User CreateUserWithAllFields(
            string privateNumber,
            string? name,
            string? lastName)
        {
            return new User(
                privateNumber,
                name,
                lastName);
        }

        public static User CreateUserWithAnyFields(
            string privateNumber)
        {
            return new User(
                privateNumber);
        }

        public User()
        {

        }
    }
}
