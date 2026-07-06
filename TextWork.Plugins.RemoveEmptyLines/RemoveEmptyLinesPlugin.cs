using System;
using System.Collections.Generic;
using System.Linq;
using TextWork.Core;

namespace TextWork.Plugins.RemoveEmptyLines;

public class RemoveEmptyLinesPlugin : IEditorPlugin
{
    public string Name => "Remove Empty Lines";
    public string Description => "Видаляє всі порожні рядки або рядки, які містять лише пробіли, з наданого тексту.";

    private string _resultText = string.Empty;

    public void Edit(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            _resultText = string.Empty;
            return;
        }

        string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        var nonEmptyLines = lines.Where(line => !string.IsNullOrWhiteSpace(line));

        _resultText = string.Join(Environment.NewLine, nonEmptyLines);
    }

    public string GetResults()
    {
        return _resultText;
    }
}