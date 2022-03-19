using Application.Domain.AuctionFolder;
using NUnit.Framework;

namespace Application.Domain.Tests.AuctionFolder
{

    [TestFixture]
    public class AuctionTest
    {
        private User steveJobs;
        private User steveWozniak;
        private User billGates;

        [SetUp]
        public void SetUp()
        {
            steveJobs = new User("Steve Jobs");
            steveWozniak = new User("Steve Wozniak");
            billGates = new User("Bill Gates");
        }

        [Test]
        public void ShouldReciveBid()
        {
            Auction Auction = new AuctionGenerator().To("Macbook Pro 15").Build();
            Assert.AreEqual(0, Auction.Bids.Count);

            Auction.Offer(new Bid(new User("Steve Jobs"), 1999));

            Assert.AreEqual(1, Auction.Bids.Count);
            Assert.AreEqual(2000, Auction.Bids[0].Value, 1);
        }

        [Test]
        public void ShouldReciveManyBids()
        {
            Auction auction = new AuctionGenerator().To("Macbook Pro 15")
                .Bid(steveJobs, 2000)
                .Bid(steveWozniak, 3000)
                .Build();

            Assert.AreEqual(2, auction.Bids.Count);
            Assert.AreEqual(2000, auction.Bids[0].Value, 0.00001);
            Assert.AreEqual(3000, auction.Bids[1].Value, 0.00001);
        }

        [Test]
        public void ShouldNotAllowsTwoConsecutivesBidsFromTheSameUser()
        {
            Auction auction = new AuctionGenerator().To("Macbook Pro 15")
                .Bid(steveJobs, 2000)
                .Bid(steveJobs, 3000)
                .Build();

            Assert.AreEqual(1, auction.Bids.Count);
            Assert.AreEqual(2000, auction.Bids[0].Value, 0.00001);
        }

        [Test]
        public void ShouldNotAllowsMoreThan5BidsFromTheSameUser()
        {
            Auction auction = new AuctionGenerator().To("Macbook Pro 15")
                .Bid(steveJobs, 2000)
                .Bid(billGates, 3000)
                .Bid(steveJobs, 4000)
                .Bid(billGates, 5000)
                .Bid(steveJobs, 6000)
                .Bid(billGates, 7000)
                .Bid(steveJobs, 8000)
                .Bid(billGates, 9000)
                .Bid(steveJobs, 10000)
                .Bid(billGates, 11000)
                .Bid(steveJobs, 12000)
                .Build();

            Assert.AreEqual(10, auction.Bids.Count);

            var last = auction.Bids.Count - 1;
            Bid lastBid = auction.Bids[last];

            Assert.AreEqual(11000, lastBid.Value, 0.00001);
        }

        [Test]
        public void ShouldDoubleLastBidByUser()
        {
            Auction auction = new AuctionGenerator().To("Macbook Pro 15")
                .Bid(steveJobs, 2000)
                .Bid(billGates, 3000)
                .Build();

            auction.DoubleBid(steveJobs);

            Assert.AreEqual(4000, auction.Bids[2].Value);
        }

        [Test]
        public void ShouldNotDoubleBidIfHasNotPreviousBid()
        {
            Auction auction = new AuctionGenerator().To("Macbook Pro 15").Build();

            auction.DoubleBid(steveJobs);

            Assert.AreEqual(0, auction.Bids.Count);
        }
    }
}
