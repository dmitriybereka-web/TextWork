using System;
using System.Collections.Generic;
using System.Linq;
using TextWork.Core;

namespace TextWork.Plugins.CleanWhitespace
{
    public class CleanWhitespacePlugin : IEditorPlugin
    {
        public string Name => "Excess Whitespace Remover";
        public string Description => "Removes multiple consecutive spaces and trims leading/trailing whitespaces from the text.";

        private string _resultText = string.Empty;

        public void Edit(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                _resultText = "Cleaned text: (Text is empty)";
                return;
            }

            string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            _resultText = string.Join(" ", words);
        }

        public string GetResults()
        {
            return _resultText;
        }
    }
}