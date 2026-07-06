using System.Text.RegularExpressions;

namespace TextWork.Plugins.MailsFinder;
using TextWork.Core;

public class MailsFinderPlugin : ISearchPlugin
{
    public string Name => "Mails Finder";
    public string Description => "Finding any mails which is in text";
    public List<string> Results { get; set; } = new();

    public void Search(string text)
    {
        Results = new();
        
        var patern = "\\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Z|a-z]{2,}\\b";
        
        var matched = Regex.Matches(text, patern, RegexOptions.IgnorePatternWhitespace);
        foreach (Match match in matched)
        {
            Results.Add(match.Value);
        }
    }
    public List<string> GetResults()
    {
        if (Results.Count != 0)
            return Results;
        return new();
    }
}