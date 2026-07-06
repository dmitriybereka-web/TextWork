using TextWork.Core;

namespace TextWork.Plugins.UpperCase;

public class UpperCasePlugin : IEditorPlugin
{
    public string Name => "Upper Case Converter";
    public string Description => "This plugin converts all text into upper case letters.";

    private string _editedText = string.Empty;

    public void Edit(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            _editedText = string.Empty;
            return;
        }

        _editedText = text.ToUpper();
    }

    public string GetResults()
    {
        return _editedText;
    }
}