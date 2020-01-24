using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;

namespace Application.Commands.Trade.Buy
{
    public class BuyRequestHandler : IRequestHandler<BuyRequest>
    {
        public Task<Unit> Handle(BuyRequest request, CancellationToken cancellationToken)
        {



            throw new NotImplementedException();
        }
    }
}
