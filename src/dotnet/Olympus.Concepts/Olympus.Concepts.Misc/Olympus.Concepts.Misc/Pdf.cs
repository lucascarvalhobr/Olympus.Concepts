using System.Text.RegularExpressions;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace Olympus.Concepts.Misc;

public sealed class Pdf
{
    private class Expense
    {   
        public string Anything { get; set; }

        public string Date { get; set; }

        public Decimal Value { get; set; }

        public Expense(string anything, string date, string value)
        {
            Anything = anything;
            Date = date;

            value = value.Replace(",", ".");
            if (decimal.TryParse(value, out decimal decimalValue))
                Value = decimalValue;
        }
    }

    public static void Read()
    {
        using PdfDocument document = PdfDocument.Open(@"C:\Users\The Office\Desktop\fatura e limite _ Banco Itaú.pdf");

        var expenses = new List<Expense>();

        foreach (Page page in document.GetPages())
        {
            var lancamentos = page.Text.Split(" / ");

            foreach (var item in lancamentos)
            {
                var expense = UnderstandExpense(item);

                if (expense == null) continue;

                expenses.Add(expense);
            }          
        }

        var aux = expenses.Sum(x => x.Value);
    }

    private static Expense UnderstandExpense(string expense)
    {
        if (expense.Contains('-'))
        {
            return UnderstandNegativeExpense(expense);
        }

        string pattern = @"(\d{2}/\d{2})R\$ (\d{1,3}(?:,\d{3})*,\d{2})";

        var regex = new Regex(pattern);

        Match match = regex.Match(expense);

        if (!match.Success)
        {
            return null;
        }

        string date = match.Groups[1].Value;
        string value = match.Groups[2].Value;

        return new Expense(expense, date, value);
    }

    private static Expense UnderstandNegativeExpense(string expense)
    {
        if(expense.Contains("cambly"))
        {

        }

        //string pattern = @"- R\$ (-?\d{1,3}(?:,\d{3})*,\d{2})";
        string pattern = @"- R\$ (-?\d{1,3}(?:\.\d{3})*(?:,\d{1,2}))";
        var regex = new Regex(pattern);

        Match match = regex.Match(expense);

        if (!match.Success)
        {
            return null;
        }

        string value = match.Groups[1].Value;

        return new Expense("", string.Empty, "-" + value);
    }
}
