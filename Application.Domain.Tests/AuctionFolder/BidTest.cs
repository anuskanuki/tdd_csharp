using Application.Domain.AuctionFolder;
using NUnit.Framework;
using System;


namespace Application.Domain.Tests
{
    [TestFixture]
    public class BidTest
    {
        private Bid bid;
        private User anuska;


        [SetUp]
        public void SetUp()
        {
            anuska = new User("Anuska");
        }


        [Test]
        public void ShouldThrowExceptionIfTheValueIsZero()
        {
            Assert.That(() => bid = new Bid(anuska, 0), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ShouldThrowExceptionIfTheValueIsNotPositive()
        {
            Assert.That(() => bid = new Bid(anuska, -1), Throws.TypeOf<ArgumentException>());
        }
    }
}
