using System.Text.RegularExpressions;
using TextWork.Core;

namespace TextWork.Plugins.SearchPlugins;

public class NumberSearchPlugin : ISearchPlugin
{
    public string Name => "Number Search";

    public string Description => "Searches for all numbers in the text.";

    public List<string> Results { get; } = new();

    public void Search(string text)
    {
        Results.Clear();

        MatchCollection matches = Regex.Matches(text, @"\d+([.,]\d+)?");

        if (matches.Count == 0)
        {
            Results.Add("No numbers found.");
            return;
        }

        Results.Add($"Found {matches.Count} number(s):");

        foreach (Match match in matches)
        {
            Results.Add(match.Value);
        }
    }
}