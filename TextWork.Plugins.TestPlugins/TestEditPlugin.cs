using TextWork.Core;

namespace TextWork.Plugins.TestPlugins;

public class TestEditPlugin: IEditorPlugin
{
    public string Name => "TestEditPlugin";
    
    public string Description => "This is a test edit plugin for demonstration purposes.";

    private string _testParameter;
    
    
    public TestEditPlugin(string testParameter)
    {
        // Initialize the plugin with the provided test parameter.
        // This is a placeholder for actual initialization logic.
        _testParameter = testParameter;
    }

    public void Edit(string text)
    {
        // This is a placeholder for actual edit logic.
        // Use parameters passed to the constructor to determine how to edit the text.
        
        // Real plugins would modify the text here.
        // Save the modified text back to the plugin's state.'
    }
    
    public string GetResults()
    {
        // Real plugins would return actual results here
        // Return result from Edit method saved in the plugin's state'.
        return $"TestEditPlugin result: {_testParameter}";
    }
}