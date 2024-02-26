using System.Text;
using Antlr4.Runtime;
using DaxAntlr;

try
{
    string input = "";
    StringBuilder text = new StringBuilder();
    Console.WriteLine("Input the chat.");

    // to type the EOF character and end the input: use CTRL+D, then press <enter>
    while ((input = Console.ReadLine()) != "\u0004")
    {
        text.AppendLine(input);
    }

    AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
    DAXLexer daxLexer = new DAXLexer(inputStream);
    CommonTokenStream commonTokenStream = new CommonTokenStream(daxLexer);
    DAXParser daxParser = new DAXParser(commonTokenStream);

    DAXParser.LineContext chatContext = daxParser.line();
    BasicDAXVisitor visitor = new BasicDAXVisitor();
    visitor.Visit(chatContext);

    foreach (var line in visitor.Lines)
    {
        Console.WriteLine("{0}", line.Text);
    }
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex);
}
