using System.Collections.Generic;
using System.Text.RegularExpressions;
using TextWork.Core;

namespace TextWork.Plugins.PhoneSearch
{
    public class PhoneSearchPlugin : ISearchPlugin
    {
        public string Name => "Пошук номерів телефонів";

        public string Description => "Знаходить усі номери телефонів у тексті.";

        public List<string> Results { get; } = new List<string>();

        public void Search(string text)
        {
            Results.Clear();

            string pattern =
                @"(\+\d{1,3}[- ]?\d{1,4}[- ]?\d{2,4}[- ]?\d{2,4}[- ]?\d{2,4})|(\(\d{3}\)\s?\d{3}-\d{4})";

            MatchCollection matches = Regex.Matches(text, pattern);

            if (matches.Count == 0)
            {
                Results.Add("Номерів телефонів не знайдено.");
                return;
            }

            foreach (Match match in matches)
            {
                Results.Add(match.Value);
            }
        }
    }
}
