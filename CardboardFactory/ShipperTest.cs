using NUnit.Framework;

namespace CardboardFactory
{
    class ShipperTest
    {
        [Test]
        public void KnowsHowManyBoxesCanFitInSmallTruck()
        {
            var shipper = CreateShipperWithTruckVolumeOf(10);

            var result = shipper.FitPackages(new CubeBox(2));

            Assert.AreEqual(1, result);
        }

        [Test]
        public void KnowsHowManyBoxesCanFitInBigTruck()
        {
            var shipper = CreateShipperWithTruckVolumeOf(60);

            var result = shipper.FitPackages(new CubeBox(3));

            Assert.AreEqual(2, result);
        }

        private static Shipper CreateShipperWithTruckVolumeOf(int volume)
        {
            var shipper = new Shipper(new Truck(volume));
            return shipper;
        }
    }
}
