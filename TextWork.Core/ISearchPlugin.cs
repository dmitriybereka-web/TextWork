namespace TextWork.Core;

public interface ISearchPlugin
{
    string Name { get; }
    string Description { get; }
    void Search(string text);
    List<string> Results { get; }
}