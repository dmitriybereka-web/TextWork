using System;
using System.Collections.Generic;
using TextWork.Core;

namespace TextWork.Plugins.SortLines
{
    public class SortLinesPlugin : IAnalyzePlugin
    {
        private readonly List<string> results = new List<string>();

        public string Name => "Сортування рядків за абеткою";

        public string Description => "Сортує всі рядки тексту за алфавітом.";

        public void Analyze(string text)
        {
            results.Clear();

            if (string.IsNullOrWhiteSpace(text))
            {
                results.Add("Текст порожній.");
                return;
            }

            string[] lines = text.Split(
                new[] { "\r\n", "\n" },
                StringSplitOptions.RemoveEmptyEntries);

            Array.Sort(lines, StringComparer.OrdinalIgnoreCase);

            foreach (string line in lines)
            {
                results.Add(line);
            }
        }

        public List<string> GetResults()
        {
            return results;
        }
    }
}