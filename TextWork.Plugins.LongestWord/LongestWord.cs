using System;
using System.Collections.Generic;
using System.Linq;
using TextWork.Core;

namespace TextWork.Plugins.LongestWord
{
    public class LongestWordPlugin : IAnalyzePlugin
    {
        private readonly List<string> _results = new List<string>();

        public string Name => "Longest Word Search";
        public string Description => "Finds the longest word in the given text and displays its length.";

        public void Analyze(string text)
        {
            _results.Clear();

            if (string.IsNullOrWhiteSpace(text))
            {
                _results.Add("Longest word: None (Text is empty)");
                return;
            }

            char[] punctuation = text.Where(char.IsPunctuation).Distinct().ToArray();

            string[] words = text
                .Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.Trim(punctuation).Trim())
                .Where(w => w.Length > 0 && w.All(char.IsLetter))
                .ToArray();

            if (words.Length == 0)
            {
                _results.Add("Longest word: None (No pure words found)");
                return;
            }

            string longestWord = words.OrderByDescending(w => w.Length).First();

            _results.Add($"Longest word: \"{longestWord}\"");
            _results.Add($"Length: {longestWord.Length} characters.");
        }

        public List<string> GetResults()
        {
            return _results;
        }
    }
}