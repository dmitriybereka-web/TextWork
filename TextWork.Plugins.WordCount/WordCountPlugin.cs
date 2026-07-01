using TextWork.Core;

namespace TextWork.Plugins.WordCount;

public class WordCountPlugin : IAnalyzePlugin
{
    public string Name => "Word Count";
    public string Description => "This plugin counts the total number of words in the provided text.";

    private int _wordCount = 0;

    public void Analyze(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            _wordCount = 0;
            return;
        }

        char[] delimiters = { ' ', '\r', '\n', '\t', '.', ',', '!', '?', '-', ';', ':' };
        string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        _wordCount = words.Length;
    }

    public List<string> GetResults()
    {
        return
        [
            $"Total words: {_wordCount}"
        ];
    }
}