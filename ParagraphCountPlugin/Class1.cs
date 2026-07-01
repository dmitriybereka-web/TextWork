using System;
using TextWork.Core;

namespace ParagraphCountPlugin
{
    public class ParagraphCountPlugin : IAnalyzePlugin
    {
        public string Name => "Paragraph Counter";

        public string Analyze(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "Paragraphs: 0";

            string[] paragraphs = text.Split(
                new[] { "\r\n\r\n", "\n\n" },
                StringSplitOptions.RemoveEmptyEntries);

            return $"Paragraphs: {paragraphs.Length}";
        }
    }
}