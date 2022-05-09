using FinanceOperation.Core.Mapping;
using FinanceOperation.Domain.Cards;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceOperation.Core.Features.DiscountCards.Create
{
    public class CreateDiscountCardCommand : IRequest, IMapTo<DiscountCard>
    {
        public string? CardNumber { get; set; }
        public double Balance { get; set; }
    }
}
