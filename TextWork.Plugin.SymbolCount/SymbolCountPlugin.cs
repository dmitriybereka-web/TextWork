using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextWork.Core;

namespace TextWork.Plugins.SymbolCount
{
    public class SymbolCountPlugin : IAnalyzePlugin
    {
        private readonly List<string> results = new();

        public string Name => "Підрахунок кількості символів";

        public string Description => "Підраховує загальну кількість символів у тексті.";

        public void Analyze(string text)
        {
            results.Clear();

            if (string.IsNullOrEmpty(text))
            {
                results.Add("Кількість символів: 0");
                return;
            }

            results.Add($"Кількість символів: {text.Length}");
        }

        public List<string> GetResults()
        {
            return results;
        }
    }
}
