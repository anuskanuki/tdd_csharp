using System.Collections.Generic;


namespace Application.Domain.AuctionFolder
{
    public class Auction
    {
        public string Description { get; set; }
        public IList<Bid> Bids { get; set; }


        public Auction(string description)
        {
            this.Description = description;
            this.Bids = new List<Bid>();
        }

        public void Offer(Bid bid)
        {
            if (Bids.Count == 0 || UserCanBid(bid.User))
            {
                Bids.Add(bid);
            }
        }

        public void DoubleBid(User user)
        {
            Bid lastBid = LastUserBid(user);
            if (lastBid != null)
            {
                Offer(new Bid(user, lastBid.Value * 2));
            }
        }

        private Bid LastUserBid(User user)
        {
            Bid last = null;
            foreach (Bid lance in Bids)
            {
                if (lance.User.Equals(user)) last = lance;
            }

            return last;
        }

        private bool UserCanBid(User user)
        {
            return (!LastBidOffered().User.Equals(user) && UserBidsCount(user) < 5);
        }

        private int UserBidsCount(User user)
        {
            int total = 0;

            foreach (var l in Bids)
            {
                if (l.User.Equals(user)) total++;
            }

            return total;
        }

        private Bid LastBidOffered()
        {
            return Bids[Bids.Count - 1];
        }
    }
}
