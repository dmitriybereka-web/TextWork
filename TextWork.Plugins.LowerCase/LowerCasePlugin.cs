using TextWork.Core;

namespace TextWork.Plugins.EditorPlugins;

public class LowerCasePlugin : IEditorPlugin
{
    private string result = string.Empty;

    public string Name => "Lower Case";

    public string Description => "Converts all text to lowercase.";

    public void Edit(string text)
    {
        result = text.ToLower();
    }

    public string GetResults()
    {
        return result;
    }
}