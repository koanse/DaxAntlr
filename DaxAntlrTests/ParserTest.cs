using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaxAntlr;
using Antlr4.Runtime;

namespace DaxAntlrTests
{
    [TestClass]
    public class ParserTest
    {
        private DAXParser Setup(string text)
        {
            AntlrInputStream inputStream = new AntlrInputStream(text);
            DAXLexer DAXLexer = new(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(DAXLexer);
            DAXParser DAXParser = new DAXParser(commonTokenStream);

            return DAXParser;
        }

        [TestMethod]
        public void TestTreatas()
        {
            DAXParser parser = Setup("TREATAS ( TEST_TABLE, TEST_COL1, TEST_COL2) \n");

            DAXParser.LineContext context = parser.line();
            BasicDAXVisitor visitor = new();
            visitor.Visit(context);

            Assert.AreEqual(1, visitor.Lines.Count);
        }

        [TestMethod]
        public void TestInvalidTreatas()
        {
            DAXParser parser = Setup("TREATAS ( TEST_TABLE, TEST_COL1 TEST_COL2) \n");

            DAXParser.LineContext context = parser.line();
            BasicDAXVisitor visitor = new();
            visitor.Visit(context);

            Assert.AreEqual(1, visitor.Lines.Count);
        }
    }
}
