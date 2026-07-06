namespace TextWork.Core;

public interface IEditorPlugin
{
    public string Name { get; }
    public string Description { get; }
    public void Edit(string text);
    public string GetResults();
}