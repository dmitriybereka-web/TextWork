using System;
using System.Collections.Generic;
using System.Linq;
using TextWork.Core;

namespace TextWork.Plugins.CleanWhitespace
{
    public class CleanWhitespacePlugin : IAnalyzePlugin
    {
        public string Name => "Excess Whitespace Remover";
        public string Description => "Removes multiple consecutive spaces and trims leading/trailing whitespaces from the text.";

        private readonly List<string> _results = new List<string>();

        public void Analyze(string text)
        {
            _results.Clear();

            if (string.IsNullOrWhiteSpace(text))
            {
                _results.Add("Cleaned text: (Text is empty)");
                return;
            }

            string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string cleanedText = string.Join(" ", words);

            _results.Add("Cleaned Text Result:");
            _results.Add(cleanedText);
        }

        public List<string> GetResults()
        {
            return _results;
        }
    }
}