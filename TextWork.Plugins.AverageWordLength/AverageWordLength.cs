using System;
using System.Collections.Generic;
using System.Linq;
using TextWork.Core;

namespace TextWork.Plugins.AverageWordLength
{
    public class AverageWordLengthPlugin : IAnalyzePlugin
    {
        public string Name => "Average Word Length";
        public string Description => "Calculates the average number of characters per word in the given text.";

        private readonly List<string> _results = new List<string>();

        public void Analyze(string text)
        {
            _results.Clear();

            if (string.IsNullOrWhiteSpace(text))
            {
                _results.Add("Average word length: 0");
                return;
            }

            char[] punctuation = text.Where(char.IsPunctuation).Distinct().ToArray();

            string[] words = text
                .Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.Trim(punctuation).Trim())
                .Where(w => w.Length > 0)
                .ToArray();

            if (words.Length == 0)
            {
                _results.Add("Average word length: 0");
                return;
            }

            double totalLetters = words.Sum(w => w.Length);
            double average = totalLetters / words.Length;

            _results.Add($"Average word length: {Math.Round(average, 2)} characters.");
            _results.Add($"Total words found: {words.Length}");
        }

        public List<string> GetResults()
        {
            return _results;
        }
    }
}