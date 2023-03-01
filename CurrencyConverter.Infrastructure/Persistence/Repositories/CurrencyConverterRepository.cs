using CurrencyConverter.Application.Common.Interfaces.Persistence;
using CurrencyConverter.Application.Converter.Commands.Converter;
using CurrencyConverter.Application.Converter.Commands.Register;
using CurrencyConverter.Application.Converter.Commands.Setter;
using CurrencyConverter.Application.Converter.Queries;
using CurrencyConverter.Domain;
using CurrencyConverter.EFCore.Common;
using CurrencyConverter.Application.Converter.Common;

namespace CurrencyConverter.Infrastructure.Persistence.Repositories
{
    public class CurrencyConverterRepository : ICurrencyConverterRepository
    {
        private readonly CurrencyConverterDbContext _dbContext;

        public CurrencyConverterRepository(CurrencyConverterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CountedResult? CountedResult(ConverterQuery request)
        {
            var countAllConverting = (from users in _dbContext.Users
                                       join history in _dbContext.UserHistories
                                        on users.Id equals history.UserId
                                       where users.PrivateNumber == history.PrivateNumber &&
                                            users.PrivateNumber != history.RecomendatorPrivateNumber &&
                                            users.PrivateNumber == request.PrivateNumber
                                       select users).ToList();

            var countByRecomendator = (from users in _dbContext.Users
                                       join history in _dbContext.UserHistories
                                        on users.Id equals history.UserId
                                       where users.PrivateNumber == history.PrivateNumber &&
                                            users.PrivateNumber == history.RecomendatorPrivateNumber &&
                                            users.PrivateNumber == request.PrivateNumber
                                       select users).ToList();

            return new CountedResult
                (
                    request.PrivateNumber,
                    countByRecomendator.Count(),
                    countByRecomendator.Count()
                );
        }

        public RegisterResult RegisterCurrency(CurrencyRegisterCommand request)
        {
           
            var existsCurrency = (from currencies in _dbContext.Currencies
                                        where currencies.Code == request.Code
                                        select currencies).FirstOrDefault();
            bool isCreated = false;

            if (existsCurrency == null)
            {
                var currency = Currency.Create(request.Code, request.Name, request.NameLatin);

                _dbContext.Add(currency);
                _dbContext.SaveChanges();

                isCreated = true;
            }

            return new RegisterResult
                (
                  isCreated
                );
        }

        public SetterResult SetCurrency(CurrencySetterCommand request)
        {
            var existsCurrency = (from currencies in _dbContext.Currencies
                                        join c in _dbContext.CurrencySetters
                                            on currencies.Id equals c.CurrencyId
                                        into temp
                                        from items in temp.DefaultIfEmpty()
                                        where currencies.Code == request.SetCurrencyCode
                                        select new CurrencySetter()
                                        {
                                            Id = currencies.Id,
                                            CurrencyId = items.CurrencyId
                                        }).FirstOrDefault();

            bool isCreated = false;

            if (existsCurrency.CurrencyId == null)
            {
                var currency = CurrencySetter.Create(existsCurrency.Id, request.SetCurrencyCode, request.SetCurrencyPrice, request.SetSellPrice);
                _dbContext.Add(currency);
                _dbContext.SaveChanges();
                isCreated = true;
            }

            return new SetterResult
            (
                isCreated
            );
          
        }

        public ConvertResult? ConvertCurrency(ConvertDataCommand request)
        {
            var historyReport = (from history in _dbContext.UserHistories
                                 join report in _dbContext.UserHistoryReports
                                   on history.Id equals report.UserHistoryId
                                 where history.PrivateNumber == request.User.PrivateNumber
                                 select new
                                 {
                                     PPrivateNumber = history.PrivateNumber,
                                     PConvertedPriceSumOfGel = report.ConvertedPriceSumOfGel,
                                     ConvertedTime = report.ConvertedDate
                                 }
                                    ).FirstOrDefault();

            if (historyReport is not null)
            {
                if (historyReport.ConvertedTime == DateTime.Today && historyReport.PConvertedPriceSumOfGel >= 100000)
                {
                    throw new Exception("User has already converted more than 100,000 GEL");
                }
            }


            var fromCurrency = (from currencies in _dbContext.Currencies
                                join setcurr in _dbContext.CurrencySetters
                                 on currencies.Id equals setcurr.CurrencyId
                                where currencies.Code == request.ConvertCurrencies.FromCurrencyCode
                                select new
                                {
                                    FromCurrencyPrice = setcurr.SetCurrencyPrice,
                                    FromCurrencySellPrice = setcurr.SetSellPrice
                                }).FirstOrDefault();

            var toCurrency = (from currencies in _dbContext.Currencies
                              join setcurr in _dbContext.CurrencySetters
                               on currencies.Id equals setcurr.CurrencyId
                              where currencies.Code == request.ConvertCurrencies.ToCurrencyCode
                              select new
                              {
                                  ToCurrencyPrice = setcurr.SetCurrencyPrice,
                                  ToCurrencySellPrice = setcurr.SetSellPrice
                              }).FirstOrDefault();
            ConvertResult? result = null;

            if (fromCurrency != null && toCurrency != null)
            {

                var price = (request.ConvertCurrencies.Price > 3000) ? true : false;


                var convertedCurrencies = (request.ConvertCurrencies.Price * fromCurrency.FromCurrencySellPrice) / toCurrency.ToCurrencySellPrice;

                var checkUser = (from users in _dbContext.Users
                                 where users.PrivateNumber == request.User.PrivateNumber
                                 select users).FirstOrDefault();

                var user = new User();

                if (checkUser == null)
                {
                    if (price)
                    {
                        user = User.CreateUserWithAllFields(
                        request.User.PrivateNumber,
                        request.User.Name,
                        request.User.LastName
                        );
                    }
                    else
                    {
                        user = User.CreateUserWithAnyFields(
                        request.User.PrivateNumber
                        );
                    }

                    _dbContext.Add(user);
                    _dbContext.SaveChanges();
                }

                var userHistory = UserHistory.Create(
                          (checkUser == null) ? user.Id : checkUser.Id,
                          request.User.PrivateNumber,
                          request.User.RecomendatorPrivateNumber,
                          convertedCurrencies
                          );

                _dbContext.Add(userHistory);
                _dbContext.SaveChanges();

                var userIsNull = (checkUser == null) ? userHistory.UserId : checkUser.Id;

                var checkHistoryReport = (from re in _dbContext.UserHistoryReports
                                          where re.UserHistoryId == userHistory.UserId
                                          select re).FirstOrDefault();

                if (checkHistoryReport == null)
                {
                    var userHistoryReport = UserHistoryReport.Create(
                        userIsNull,
                        userHistory.Id,
                        0.00,
                        convertedCurrencies
                        );
                    if (request.ConvertCurrencies.FromCurrencyCode == "GEL")
                    {
                        userHistoryReport.ConvertedPriceSumOfGel = convertedCurrencies;
                    }

                    _dbContext.Add(userHistoryReport);
                    _dbContext.SaveChanges();
                }
                else
                {
                    checkHistoryReport.ConvertedPriceSum += convertedCurrencies;
                    if (request.ConvertCurrencies.FromCurrencyCode == "GEL")
                    {
                        checkHistoryReport.ConvertedPriceSumOfGel += convertedCurrencies;
                    }
                    _dbContext.Update(checkHistoryReport);
                    _dbContext.SaveChanges();
                }

                result = new ConvertResult
                    (
                        request.ConvertCurrencies.FromCurrencyCode,
                        request.ConvertCurrencies.ToCurrencyCode,
                        $"1 {request.ConvertCurrencies.FromCurrencyCode} = {(1 * fromCurrency.FromCurrencySellPrice) / toCurrency.ToCurrencySellPrice} EUR",
                        convertedCurrencies
                    );

            }

            return result;
        }
    }
}
