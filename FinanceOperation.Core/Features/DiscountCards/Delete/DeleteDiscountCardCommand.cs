using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceOperation.Core.Features.DiscountCards.Delete
{
    public class DeleteDiscountCardCommand : IRequest
    {
        public string? CardNumber { get; set; }
    }
}
