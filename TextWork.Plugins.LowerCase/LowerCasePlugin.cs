using TextWork.Core;

namespace TextWork.Plugins.TransformPlugins;

public class LowerCasePlugin : ITransformPlugin
{
    public string Name => "Lower Case";

    public string Description => "Converts all text to lowercase.";

    public string Transform(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        return text.ToLower();
    }
}