using System;

namespace Application.Domain.AuctionFolder
{
    public class Bid
    {
        public User User { get; private set; }
        public double Value { get; private set; }


        public Bid(User user, double value)
        {
            if (value <= 0) throw new ArgumentException
                    ("The bid should be a positive value.");

            this.User = user;
            this.Value = value;
        }
    }
}
