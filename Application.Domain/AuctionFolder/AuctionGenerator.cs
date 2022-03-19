using System;

namespace Application.Domain.AuctionFolder
{
    public class AuctionGenerator
    {
        private Auction auction;

        public AuctionGenerator To(String descricao)
        {
            this.auction = new Auction(descricao);
            return this;
        }

        public AuctionGenerator Bid(User user, double value)
        {
            auction.Offer(new Bid(user, value));
            return this;
        }

        public Auction Build()
        {
            return auction;
        }

    }
}
