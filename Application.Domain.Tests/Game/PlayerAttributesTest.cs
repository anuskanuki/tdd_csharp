using NUnit.Framework;


namespace Application.Domain.Tests
{
    [TestFixture]
    public class PlayerAttributesTest
    {
        [Test]
        public void ShouldNotListEmptyWeaponsList()
        {
            var sut = new PlayerAttributes();

            Assert.That(sut.Weapons, Is.All.Not.Empty);
        }


        [Test]
        public void ShouldHaveWeaponAk47()
        {
            var sut = new PlayerAttributes();

            Assert.That(sut.Weapons, Contains.Item("AK-47"));
        }

        [Test]
        public void ShouldHaveAtLeastOneArtificial()
        {
            var sut = new PlayerAttributes();

            Assert.That(sut.Weapons, Has.Some.Contains("Artificial"));
        }


        [Test]
        public void ShouldHaveTwoForceWeapons()
        {
            var sut = new PlayerAttributes();

            Assert.That(sut.Weapons, Has.Exactly(2).EndWith("Strength").IgnoreCase);
        }

        [Test]
        public void ShouldNotCountMoreWeaponTypes()
        {
            var sut = new PlayerAttributes();

            Assert.That(sut.Weapons, Is.Unique);
        }

        [Test]
        public void ShouldNotHaveFlyWeapon()
        {
            var sut = new PlayerAttributes();

            Assert.That(sut.Weapons, Has.None.EqualTo("Voar"));
        }

        [Test]
        public void ShouldHaveAllCorrectWeapons()
        {
            var sut = new PlayerAttributes();

            var listaArmasEsperadas = new[]
            {
                "Agility",
                "Agility Strength",
                "Artificial Intelligence",
                "AK-47",
                "Strength",
            };

            Assert.That(sut.Weapons, Is.EquivalentTo(listaArmasEsperadas));
        }

        [Test]
        public void WeaponsShouldBeInAlphabeticOrder()
        {
            var sut = new PlayerAttributes();

            Assert.That(sut.Weapons, Is.Ordered);
        }
    }
}
