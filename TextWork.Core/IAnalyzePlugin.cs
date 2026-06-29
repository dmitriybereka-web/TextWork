namespace TextWork.Core;

public interface IAnalyzePlugin
{
    public string Name { get; }
    public string Description { get; }
    
    public void Analyze(string text);
    
    public List<string> GetResults();
    
}