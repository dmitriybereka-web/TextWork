using System.Text.RegularExpressions;
using TextWork.Core;

namespace MostUsedWordsPlugin;

public class MostUsedWordsPlugin : IAnalyzePlugin
{
    private readonly List<string> _results = new();

    public string Name => "Most Used Words";

    public string Description => "Finds the most frequently used words in the text.";

    public void Analyze(string text)
    {
        _results.Clear();

        if (string.IsNullOrWhiteSpace(text))
        {
            _results.Add("The text is empty.");
            return;
        }

        var words = Regex.Matches(text.ToLower(), @"\b[\p{L}\p{N}']+\b")
                         .Select(m => m.Value);

        var topWords = words
            .GroupBy(w => w)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Key)
            .Take(10);

        foreach (var word in topWords)
        {
            _results.Add($"{word.Key} - {word.Count()}");
        }
    }

    public List<string> GetResults()
    {
        return _results;
    }
}