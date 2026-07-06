namespace TextWork.Core;

public interface ITransformPlugin
{
    string Name { get; }
    string Description { get; }

    string Transform(string text);
}