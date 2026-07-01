using System;
using System.Collections.Generic;
using System.Linq;
using TextWork.Core;

namespace TextWork.Plugins.UniqueWords
{
    public class UniqueWordsPlugin : IAnalyzePlugin
    {
        public string Name => "Unique Words List";
        public string Description => "Extracts a sorted list of unique words found in the text, ignoring case, numbers, and URLs.";

        private readonly List<string> _results = new List<string>();

        public void Analyze(string text)
        {
            _results.Clear();

            if (string.IsNullOrWhiteSpace(text))
            {
                _results.Add("Unique words: None (Text is empty)");
                return;
            }

            char[] punctuation = text.Where(char.IsPunctuation).Distinct().ToArray();

            string[] uniqueWords = text
                .Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.Trim(punctuation).Trim().ToLowerInvariant())
                .Where(w => w.Length > 0 && w.All(char.IsLetter))
                .Distinct()
                .OrderBy(w => w)
                .ToArray();

            if (uniqueWords.Length == 0)
            {
                _results.Add("Unique words: None (No valid words found)");
                return;
            }

            _results.Add($"Total unique words found: {uniqueWords.Length}");

            string commaSeparatedWords = string.Join(", ", uniqueWords);

            _results.Add("Words:");
            _results.Add(commaSeparatedWords);
        }

        public List<string> GetResults()
        {
            return _results;
        }
    }
}