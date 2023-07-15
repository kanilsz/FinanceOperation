using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Core.Features.BankCards.Create;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using MediatR;
using Moq;
using Xunit;

namespace FinanceOperation.Tests;

public class BankCardsFeatureTest
{
    private static IMapper _mapper;
    public BankCardsFeatureTest()
    {
        if (_mapper == null)
        {
            MapperConfiguration mappingConfig = new(mc =>
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
        Mock<IBankCardRepository> mock = new();
        BankCard bankCard = new()
        {
            CardNumber = "Test1",
            Balance = 1000,
        };
        CreateBankCardCommand bankCardRequest = new()
        {
            CardNumber = "Test1",
            Balance = 1000
        };
        CancellationToken token = default;
        _ = mock.Setup(repo => repo.Create(bankCard, token)).Returns(Task.CompletedTask);
        CreateBankCardCommandHandler command = new(mock.Object);

        //Act
        Unit bankCardResponse = await command.Handle(bankCardRequest, token);

        //Assert
        _ = Assert.IsType<Unit>(bankCardResponse);
        Assert.Equal(Unit.Value, bankCardResponse);
    }

    //[Fact]
    //public async void GetBankCardsList()
    //{
    //    //Arrange
    //    var mockRepository = new Mock<IBankCardRepository>();
    //    CancellationToken token = default;
    //    var bankCardsRequest = new GetBankCardListQuery();

    //    mockRepository.Setup(repo => repo.GetBankCardsList(token)).Returns(GetListOfBankCard());
    //    var command = new GetBankCardListQueryHandler(mockRepository.Object, _mapper);

    //    //Act
    //    var bankCardList = await command.Handle(bankCardsRequest, token);

    //    //Assert
    //    Assert.NotEmpty(bankCardList);
    //    // var result = Assert.IsAssignableFrom<IEnumerable<BankCardDto>>(bankCardList);
    //    // Assert.Equal((IEnumerable<BankCardDto>)_mapper.Map<BankCardDto>(GetListOfBankCard()),bankCardList);

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
