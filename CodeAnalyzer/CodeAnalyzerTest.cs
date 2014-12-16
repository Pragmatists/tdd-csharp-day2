using System;
using NUnit.Framework;

namespace CodeAnalyzer
{
    public class CodeAnalyzerTest
    {
        private CodeAnalyzer codeAnalyzer;
        private const string SomeLineContent = "some line content";

        [SetUp]
        public void CreateCodeAnalyzer()
        {
            codeAnalyzer = new CodeAnalyzer();
        }

        [Test]
        public void ShouldCountLines()
        {
            codeAnalyzer.MeasureLine(SomeLineContent);
            Assert.AreEqual(1, codeAnalyzer.LineCount);

            codeAnalyzer.MeasureLine(SomeLineContent);
            codeAnalyzer.MeasureLine(SomeLineContent);
            Assert.AreEqual(3, codeAnalyzer.LineCount);
        }

        [Test]
        public void ShouldCountMeanWidth()
        {
            codeAnalyzer.MeasureLine(ALineOf(30));
            codeAnalyzer.MeasureLine(ALineOf(10));

            Assert.AreEqual(20, codeAnalyzer.MeanLineWidth);
        }

        [Test]
        public void ShouldRecordLineCountForWidth()
        {
            codeAnalyzer.MeasureLine(ALineOf(30));
            codeAnalyzer.MeasureLine(ALineOf(30));
            codeAnalyzer.MeasureLine(ALineOf(10));

            Assert.AreEqual(2, codeAnalyzer.LineCountForWidth(30));
            Assert.AreEqual(1, codeAnalyzer.LineCountForWidth(10));
            Assert.AreEqual(0, codeAnalyzer.LineCountForWidth(100));
        }

        [Test]
        public void ShouldRecordWidestLineNumberAndWidth()
        {
            codeAnalyzer.MeasureLine(ALineOf(10));
            codeAnalyzer.MeasureLine(ALineOf(30));

            Assert.AreEqual(2, codeAnalyzer.WidestLineNumber);
            Assert.AreEqual(30, codeAnalyzer.WidestLineLength);
        }

        private static String ALineOf(int chars)
        {
            return new String('A', chars);
        }
    }
}