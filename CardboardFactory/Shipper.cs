namespace CardboardFactory
{
    public class Shipper
    {
        private Truck truck;

        public Shipper(Truck truck)
        {
            this.truck = truck;
        }

        public int FitPackages(CubeBox cubeBox)
        {
            return truck.Volume / cubeBox.Volume;
        }
    }
}