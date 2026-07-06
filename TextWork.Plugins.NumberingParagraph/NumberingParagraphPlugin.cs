namespace TextWork.Plugins.NumberingParagraph;
using TextWork.Core;

public class NumberingParagraphPlugin : IEditorPlugin
{
    public string Name => "Numbering Paragraph";
    public string Description => "Numbering Paragraphs by order";
    public string? Result = null;

    public void Edit(string text)
    {
        var lines = text.Split('\n');
        
        for (int i = 0; i < lines.Length; ++i)
        {
            lines[i] = $"{i + 1}. {lines[i]}";
        }
        
        Result = string.Join(Environment.NewLine, lines);
    }

    public string GetResults()
    {
        if (Result != null)
            return Result;
        return string.Empty;
    }
}

