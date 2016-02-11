namespace CardboardFactory
{
    public class Manufacturer
    {
        private int squareUnits;

        public void AddCardboard(int squareUnits)
        {
            this.squareUnits = squareUnits;
        }

        public int PossiblePackages(CubeBox cubeBox)
        {
            return squareUnits / cubeBox.Area;
        }
    }
}