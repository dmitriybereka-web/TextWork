using TextWork.Core;

namespace TextWork.Plugins.UpperCase;

public class UpperCasePlugin : IAnalyzePlugin
{
    public string Name => "Upper Case Converter";
    public string Description => "This plugin converts all text into upper case letters.";

    private string _resultText = string.Empty;

    public void Analyze(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            _resultText = string.Empty;
            return;
        }
        _resultText = text.ToUpper();
    }

    public List<string> GetResults()
    {
        return
        [
            "Converted text:",
            _resultText
        ];
    }
}