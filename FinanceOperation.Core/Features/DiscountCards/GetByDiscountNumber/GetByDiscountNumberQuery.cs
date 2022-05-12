using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceOperation.Core.Features.DiscountCards.GetByDiscountNumber
{
    public class GetByDiscountNumberQuery : IRequest<DiscountCardDto>
    {
        public string? CardNumber { get; set; }
    }
}
