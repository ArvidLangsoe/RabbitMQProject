using Application.Commands.Trade.Models;
using MediatR;

namespace Application.Commands.Trade.Buy
{

    //Where to put these. Are they domain objects? Are they something else? They are definetly not application classes.
    public class BuyRequest : TradeRequest, IRequest
    {
        private double MaxPrice { get; set; }
    }
}
