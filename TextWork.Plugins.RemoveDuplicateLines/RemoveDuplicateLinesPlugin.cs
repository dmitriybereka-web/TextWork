using System;
using System.Collections.Generic;
using System.Linq;
using TextWork.Core;

namespace TextWork.Plugins.RemoveDuplicateLines
{
    public class RemoveDuplicateLinesPlugin : IEditorPlugin
    {
        public string Name => "Duplicate Line Remover";
        public string Description => "Removes duplicate lines from the text, keeping only the first occurrence.";

        private string _resultText = string.Empty;

        public void Edit(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                _resultText = "Text with duplicates removed: (Text is empty)";
                return;
            }

            string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            var uniqueLines = lines
                .Select(line => line.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToArray();

            _resultText = string.Join(Environment.NewLine, uniqueLines);
        }

        public string GetResults()
        {
            return _resultText;
        }
    }
}