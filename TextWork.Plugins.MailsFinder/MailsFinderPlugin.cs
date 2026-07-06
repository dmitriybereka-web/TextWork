using System.Text.RegularExpressions;

namespace TextWork.Plugins.MailsFinder;
using TextWork.Core;

public class MailsFinderPlugin : IAnalyzePlugin
{
    public string Name => "Mails Finder";
    public string Description => "Finding any mails which is in text";
    public List<string>? Result = null;

    public void Analyze(string text)
    {
        Result = new();
        
        var patern = "\\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Z|a-z]{2,}\\b";
        
        var matched = Regex.Matches(text, patern, RegexOptions.IgnorePatternWhitespace);
        foreach (Match match in matched)
        {
            Result.Add(match.Value);
        }
    }

    public List<string> GetResults()
    {
        if (Result != null)
            return Result;
        return new();
    }
}