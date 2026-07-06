using TextWork.Core;

namespace TextWork.Plugins.TestPlugins;

public class TestSearchPlugin: ISearchPlugin
{
    public string Name => "Test Search Plugin";
    public string Description => "This is a test search plugin that finds all lines containing a specific search word in the text.";
    
    private string _searchWord;
    
    public TestSearchPlugin(string searchWord)
    {
        _searchWord = searchWord;
    }

    private List<string> results = new List<string>();
    
    public void Search(string text)
    {
        results.Clear();
        
        if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(_searchWord))
        {
            return;
        }
        var lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
        foreach (var t in lines)
        {
            if (t.Contains(_searchWord, StringComparison.OrdinalIgnoreCase))
            {
                results.Add(t);
            }
        }
    }

    public List<string> Results => results;
}