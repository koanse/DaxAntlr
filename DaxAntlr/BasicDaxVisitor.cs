namespace DaxAntlr
{
    public class BasicDAXVisitor : DAXBaseVisitor<object>
    {
        public List<DAXLine> Lines = new();

        public override object VisitLine(DAXParser.LineContext context)
        {
            var expression = context.TABLE_EXPRESSION();

            DAXLine line = new() { Text = expression.ToString() };
            Lines.Add(line);

            return line;
        }
    }
}