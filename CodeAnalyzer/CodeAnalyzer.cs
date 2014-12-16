using System.Collections.Generic;

namespace CodeAnalyzer
{
    internal class CodeAnalyzer
    {
        private int totalChars;
        private readonly Dictionary<int, int> lineLengths = new Dictionary<int, int>();

        public void MeasureLine(string line)
        {
            LineCount++;
            totalChars += line.Length;
            if (!lineLengths.ContainsKey(line.Length))
            {
                lineLengths.Add(line.Length, 1);
            }
            else
            {
                var currentCount = lineLengths[line.Length];
                lineLengths[line.Length] = ++currentCount;
            }

            if (line.Length > WidestLineLength)
            {
                WidestLineNumber = LineCount;
                WidestLineLength = line.Length;
            }
        }

        public int LineCount { get; private set; }

        public int MeanLineWidth
        {
            get { return totalChars/LineCount; }
        }

        public int WidestLineLength { get; private set; }
        public int WidestLineNumber { get; private set; }

        public int LineCountForWidth(int width)
        {
            if (!lineLengths.ContainsKey(width))
            {
                return 0;
            }
            return lineLengths[width];
        }
    }
}