using System.Collections.Generic;

namespace CodeAnalyzer
{
    internal class LineLengthsHistogram
    {
        private readonly Dictionary<int, int> lineLengths = new Dictionary<int, int>();

        public void UpdateLengthsHistogram(int lineLength)
        {
            if (NotInHistogram(lineLength))
            {
                AddFirstOccurence(lineLength);
            }
            else
            {
                UpdateOccurenceCount(lineLength);
            }
        }

        private bool NotInHistogram(int lineLength)
        {
            return !lineLengths.ContainsKey(lineLength);
        }

        private void UpdateOccurenceCount(int lineLength)
        {
            var currentCount = lineLengths[lineLength];
            lineLengths[lineLength] = ++currentCount;
        }

        private void AddFirstOccurence(int lineLength)
        {
            lineLengths.Add(lineLength, 1);
        }

        public int LineCountForWidth(int width)
        {
            if (NotInHistogram(width))
            {
                return 0;
            }
            return lineLengths[width];
        }
    }
}

