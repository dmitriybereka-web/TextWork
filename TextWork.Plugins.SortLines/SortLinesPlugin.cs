using System;
using TextWork.Core;

namespace TextWork.Plugins.SortLines
{
    public class SortLinesPlugin : IEditorPlugin
    {
        private string result = "";

        public string Name => "Сортування рядків за абеткою";

        public string Description => "Сортує рядки тексту в алфавітному порядку.";

        public void Edit(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                result = "Текст порожній.";
                return;
            }

            string[] lines = text.Split(
                new[] { "\r\n", "\n" },
                StringSplitOptions.RemoveEmptyEntries);

            Array.Sort(lines, StringComparer.OrdinalIgnoreCase);

            result = string.Join(Environment.NewLine, lines);
        }

        public string GetResults()
        {
            return result;
        }
    }
}