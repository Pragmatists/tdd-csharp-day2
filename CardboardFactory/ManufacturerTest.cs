using NUnit.Framework;

namespace CardboardFactory
{
    
    class ManufacturerTest
    {
        [Test]
        public void KnowsHowManySmallBoxesCanBeMade()
        {
            var manufacturer = ManufacturerWithCardboard(50);

            var result = manufacturer.PossiblePackages(new CubeBox(2));

            Assert.AreEqual(2, result);
        }

        [Test]
        public void KnowsHowManyBigBoxesCanBeMade()
        {
            var manufacturer = ManufacturerWithCardboard(600);

            var result = manufacturer.PossiblePackages(new CubeBox(10));

            Assert.AreEqual(1, result);
        }

        private static Manufacturer ManufacturerWithCardboard(int cardboardSquareUnits)
        { 
            var manufacturer = new Manufacturer();
            manufacturer.AddCardboard(cardboardSquareUnits);
            return manufacturer;
        }
    }
}
