using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextWork.Core;

namespace TextWork.Plugins.ShortestWord
{
    public class ShortestWordPlugin : IAnalyzePlugin
    {
        private List<string> results = new List<string>();

        public string Name => "Пошук найкоротшого слова";

        public string Description => "Знаходить найкоротше слово у тексті.";

        public void Analyze(string text)
        {
            results.Clear();

            if (string.IsNullOrWhiteSpace(text))
            {
                results.Add("Текст порожній.");
                return;
            }

            char[] separators =
            {
                ' ', '\n', '\r', '\t',
                '.', ',', ';', ':', '!', '?',
                '(', ')', '[', ']', '{', '}',
                '"', '\'', '-', '/', '\\'
            };

            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                results.Add("Слова не знайдено.");
                return;
            }

            string shortestWord = words[0];

            foreach (string word in words)
            {
                if (word.Length < shortestWord.Length)
                {
                    shortestWord = word;
                }
            }

            results.Add("Найкоротше слово: " + shortestWord);
            results.Add("Довжина: " + shortestWord.Length);
        }

        public List<string> GetResults()
        {
            return results;
        }
    }
}
