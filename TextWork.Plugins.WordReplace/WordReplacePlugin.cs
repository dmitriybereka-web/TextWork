using System;
using System.Collections.Generic;
using System.Linq;
using TextWork.Core;

namespace TextWork.Plugins.WordReplace
{
    public class WordReplacePlugin : IAnalyzePlugin
    {
        public string Name => "Replace text or word";
        public string Description => "Replaces a specific phrase or word with a new one";
        
        private readonly List<string> _results = new List<string>();
        private readonly string _targetWord;
        private readonly string _replacementWord;
        
        public WordReplacePlugin(string targetWord, string replacementWord)
        {
            _targetWord = targetWord ?? throw new ArgumentNullException(nameof(targetWord));
            _replacementWord = replacementWord ?? "";
        }

        public void Analyze(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                _results.Add("Вхідний текст порожній.");
                return;
            }
            
            if (text.Contains(_targetWord, StringComparison.OrdinalIgnoreCase))
            {
                string modifiedText = text.Replace(_targetWord, _replacementWord);
                
                _results.Add($"(Успішно) Замінено '{_targetWord}' на '{_replacementWord}'.");
                _results.Add($"Результат: {modifiedText}");
            }
            else
            {
                _results.Add($"(ІНФО) Слово '{_targetWord}' не знайдено в тексті.");
            }
        }

        public List<string> GetResults()
        {
            return _results;
        }
    }
}