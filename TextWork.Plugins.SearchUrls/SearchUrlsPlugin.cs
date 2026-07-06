using System;
using System.Collections.Generic;
using System.Linq;
using TextWork.Core;

namespace TextWork.Plugins.SearchUrls
{
    public class SearchUrlsPlugin : ISearchPlugin
    {
        public string Name => "URL Link Search HELLO WORLD";
        public string Description => "Finds and extracts all web links (URLs) starting with http:// or https:// from the text.";

        public List<string> Results { get; } = new List<string>();

        public void Search(string text)
        {
            Results.Clear();

            if (string.IsNullOrWhiteSpace(text))
            {
                Results.Add("No URLs found (Text is empty).");
                return;
            }

            char[] punctuation = text.Where(char.IsPunctuation)
                                     .Distinct()
                                     .Where(c => c != '/' && c != ':' && c != '?' && c != '=' && c != '&')
                                     .ToArray();

            string[] urls = text
                .Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.Trim(punctuation).Trim())
                .Where(w => w.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                             w.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                .Distinct()
                .ToArray();

            if (urls.Length == 0)
            {
                Results.Add("No URLs found in the text.");
                return;
            }

            foreach (var url in urls)
            {
                Results.Add(url);
            }
        }
    }
}