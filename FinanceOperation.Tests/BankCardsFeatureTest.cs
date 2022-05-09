using AutoMapper;
using FinanceOperation.Core.Features.BankCards.Create;
using FinanceOperation.Core.Features.BankCards.GetList;
using FinanceOperation.Core.Mapping;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using MediatR;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FinanceOperation.Tests
{
    public class BankCardsFeatureTest
    {
        private static IMapper? _mapper;
        public BankCardsFeatureTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                _mapper = mappingConfig.CreateMapper();
            }
        }

        [Fact]
        public async void CreateBankCard()
        {
            //Arrange
            var mock = new Mock<IBankCardRepository>();
            var bankCard = new BankCard
            {
                CardNumber = "Test1",
                Balance = 1000,
            };
            var bankCardRequest = new CreateBankCardCommand
            {
                CardNumber = "Test1",
                Balance = 1000
            };
            CancellationToken token = default;
            mock.Setup(repo => repo.Create(bankCard, token)).Returns(Task.CompletedTask);
            var command = new CreateBankCardCommandHandler(mock.Object);

            //Act
            var bankCardResponse = await command.Handle(bankCardRequest, token);

            //Assert
            Assert.IsType<Unit>(bankCardResponse);
            Assert.Equal(Unit.Value, bankCardResponse);
        }

        //[Fact]
        //public async void GetBankCardsList()
        //{
        //    //Arrange
        //    var mockRepository = new Mock<IBankCardRepository>();
        //    CancellationToken token = default;
        //    var bankCardsRequest = new GetBankCardListFeature();

        //    mockRepository.Setup(repo => repo.GetBankCardsList(token)).Returns(GetListOfBankCard());
        //    var command = new GetBankCardListFeatureHandler(mockRepository.Object, _mapper);

        //    //Act
        //    var bankCardList = await command.Handle(bankCardsRequest, token);

        //    //Assert
        //    Assert.NotEmpty(bankCardList);
        //   // var result = Assert.IsAssignableFrom<IEnumerable<BankCardDto>>(bankCardList);
        //  // Assert.Equal((IEnumerable<BankCardDto>)_mapper.Map<BankCardDto>(GetListOfBankCard()),bankCardList);

        //    async Task<IList<BankCard>> GetListOfBankCard()
        //    {
        //        var bankCardLists = new List<BankCard>()
        //        {
        //            new BankCard
        //            {
        //                CardNumber = "Test1",
        //                Balance = 1000,
        //            },
        //            new BankCard
        //            {
        //                CardNumber = "Test2",
        //                Balance = 1000,
        //            },
        //            new BankCard
        //            {
        //                CardNumber = "Test3",
        //                Balance = 1000,
        //            },
        //        };

        //        return await Task.FromResult(bankCardLists);
        //    }

        //}
    }
}