using TextWork.Core;

namespace TextWork.Plugins.ParagraphCountPlugin;

public class ParagraphCountPlugin : IAnalyzePlugin
{
    private readonly List<string> _results = new();

    public string Name => "Paragraph Counter";

    public string Description => "Counts the number of paragraphs in the text.";

    public void Analyze(string text)
    {
        _results.Clear();

        if (string.IsNullOrWhiteSpace(text))
        {
            _results.Add("Paragraph count: 0");
            return;
        }

        string[] paragraphs = text.Split(
            new[] { "\r\n\r\n", "\n\n" },
            StringSplitOptions.RemoveEmptyEntries);

        _results.Add($"Paragraph count: {paragraphs.Length}");
    }

    public List<string> GetResults()
    {
        return _results;
    }
}