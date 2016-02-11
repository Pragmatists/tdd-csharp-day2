using System;

namespace CardboardFactory
{
    public class CubeBox
    {
        private readonly int edgeLength;

        public CubeBox(int edgeLength)
        {
            this.edgeLength = edgeLength;
        }

        public int Area { get { return 6*edgeLength*edgeLength; } }
        public int Volume { get { return (int) Math.Pow(edgeLength, 3); } }
    }
}
