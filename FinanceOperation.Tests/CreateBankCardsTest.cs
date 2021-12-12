using FinanceOperation.Core.Features.BankCards.Create;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FinanceOperation.Tests
{
    public class CreateBankCardsTest
    {
        [Fact]
        public async void CreateBankCard()
        {
            //Arrange
            var mock = new Mock<IBankCardRepository>();
            var dateTime = DateTime.UtcNow;
            var bankCard = new BankCard
            {
                CardNumber = "Test1",
                Balance = 1000,
                CreatedAtUtc = dateTime,
                UpdatedAtUtc = dateTime
            };
            var bankCardRequest = new CreateBankCardFeature
            {
                CardNumber = "Test1",
                Balance = 1000
            };
            CancellationToken token = default;
            mock.Setup(repo => repo.Create(bankCard, token)).Returns(Task.CompletedTask);
            var command = new CreateBankCardFeatureHandler(mock.Object);

            //Act
            var result = command.Handle(bankCardRequest, token);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Unit>(result.Result);
            Assert.Equal(Unit.Value, result.Result);
        }
    }
}