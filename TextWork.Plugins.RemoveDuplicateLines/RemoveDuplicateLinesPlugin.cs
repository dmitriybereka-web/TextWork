using System;
using System.Collections.Generic;
using System.Linq;
using TextWork.Core;

namespace TextWork.Plugins.RemoveDuplicateLines
{
    public class RemoveDuplicateLinesPlugin : IAnalyzePlugin
    {
        public string Name => "Duplicate Line Remover";
        public string Description => "Removes duplicate lines from the text, keeping only the first occurrence.";

        private readonly List<string> _results = new List<string>();

        public void Analyze(string text)
        {
            _results.Clear();

            if (string.IsNullOrWhiteSpace(text))
            {
                _results.Add("Cleaned text: (Text is empty)");
                return;
            }

            string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            var uniqueLines = lines
                .Select(line => line.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            _results.Add("Text with duplicates removed:");

            foreach (var line in uniqueLines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    _results.Add(line);
                }
            }
        }

        public List<string> GetResults()
        {
            return _results;
        }
    }
}