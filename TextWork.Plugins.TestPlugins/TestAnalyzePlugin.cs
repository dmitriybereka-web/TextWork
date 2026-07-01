using TextWork.Core;

namespace TextWork.Plugins.TestPlugins;

public class TestAnalyzePlugin: IAnalyzePlugin
{
    public string Name => "TestAnalyzePlugin";
    public string Description => "This is a test analyze plugin for demonstration purposes.";
    
    public void Analyze(string text)
    {
        // This is a test analyze plugin, so we don't perform any actual analysis.
        // In a real plugin, you would implement your analysis logic here.
    }
    
    
    public List<string> GetResults()
    {
        return
        [
            "TestAnalyzePlugin result row 1",
            "TestAnalyzePlugin result row 2",
            "TestAnalyzePlugin result row 3"
        ];
    }
}