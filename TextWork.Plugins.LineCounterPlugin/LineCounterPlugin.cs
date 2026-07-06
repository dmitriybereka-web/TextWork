using TextWork.Core;

namespace TextWork.Plugins.LineCounterPlugin;

public class LineCounterPlugin : IAnalyzePlugin
{
    public string Name => "Line Counter Plugin";
    public string Description => "Counts the total number of lines, as well as the number of blank and filled lines in a document.";

    private int _totalLines = 0;
    private int _emptyLines = 0;
    private int _nonEmptyLines = 0;

    public void Analyze(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            _totalLines = 0;
            _emptyLines = 0;
            _nonEmptyLines = 0;
            return;
        }

        string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        _totalLines = lines.Length;
        _emptyLines = 0;
        _nonEmptyLines = 0;

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                _emptyLines++;
            }
            else
            {
                _nonEmptyLines++;
            }
        }
    }

    public List<string> GetResults()
    {
        return new List<string>
        {
            $"Total number of rows: {_totalLines}",
            $"Number of filled lines: {_nonEmptyLines}",
            $"Number of empty lines: {_emptyLines}"
        };
    }
}