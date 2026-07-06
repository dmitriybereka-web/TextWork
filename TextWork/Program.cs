using TextWork.Core;
using TextWork.Plugins.TransformPlugins;

/*
 *
 *
 * Teacher: Vasyl Kovalov raid3r81@gmail.com
 *
 * Team:
 * Bereka Dmytro dmitriy.bereka@gmail.com
 * Kovalevskiy Dmytro kovalevskijdmitro29@gmail.com
 * Rui Dariia dasharuy2007@gmail.com
 * Hryn Tetiana tana2501201010@gmail.com
 * Karelov Yevhenii krv.jeka@gmail.com
 * Perets Artem artem.perets.30@gmail.com
 * Zybin Nikita nikitos.zybin@gmail.com 
 * ..
 * ..
 */

var textForAnalysis = """
                      Document Processing Test File
                      
                      This document was created to test different text processing plugins.
                      
                      John Smith works as a software engineer at Example Solutions Ltd.
                      His email address is john.smith@example.com, and his backup email is support@test.org.
                      
                      For business inquiries, please call +1-202-555-0175 or +44 20 7946 0958.
                      
                      The project officially started on 15 March 2025 and is expected to finish on 30 September 2026.
                      
                      Useful websites:
                      https://example.com
                      https://docs.example.com
                      https://github.com/example/project
                      
                      The quick brown fox jumps over the lazy dog.
                      The quick brown fox jumps over the lazy dog.
                      
                      Artificial Intelligence is changing the way people work.
                      Machine learning, cloud computing, and cybersecurity are becoming increasingly important.
                      
                      This paragraph contains several repeated words.
                      Document document DOCUMENT processing Processing processing.
                      
                      The following line contains extra spaces.
                      
                      
                      This      line      contains      multiple      spaces.
                      
                      
                      Some numbers:
                      15
                      256
                      1024
                      3.14159
                      -42
                      
                      The longest English word in this document is:
                      pseudopseudohypoparathyroidism
                      
                      Palindrome examples:
                      level
                      madam
                      racecar
                      
                      Shopping list:
                      - Apples
                      - Bananas
                      - Milk
                      - Bread
                      - Cheese
                      
                      End of document.
                      
                      
                      """;


var analyzePlugins = new List<IAnalyzePlugin>
 {
    //new TextWork.Plugins.TestPlugins.TestAnalyzePlugin(),
    new TextWork.Plugins.SymbolCount.SymbolCountPlugin(),
    new TextWork.Plugins.AverageWordLength.AverageWordLengthPlugin(),
    new TextWork.Plugins.ShortestWord.ShortestWordPlugin(),
    new TextWork.Plugins.ParagraphCountPlugin.ParagraphCountPlugin(),
    new TextWork.Plugins.WordCount.WordCountPlugin(),
    new TextWork.Plugins.LongestWord.LongestWordPlugin(),
    new TextWork.Plugins.UniqueWords.UniqueWordsPlugin(),
    new TextWork.Plugins.UpperCase.UpperCasePlugin(),
    new TextWork.Plugins.UniqueWords.UniqueWordsPlugin(),
    new TextWork.Plugins.MostUsedWords.MostUsedWordsPlugin(),
    new TextWork.Plugins.LineCounterPlugin.LineCounterPlugin(),
    new TextWork.Plugins.SortLines.SortLinesPlugin(),
    new TextWork.Plugins.CleanWhitespace.CleanWhitespacePlugin(),
    new TextWork.Plugins.RemoveDuplicateLines.RemoveDuplicateLinesPlugin()
 };

Console.WriteLine("Analyzing text:");

var transformPlugins = new List<ITransformPlugin>
{
    new LowerCasePlugin()
};

foreach (var plugin in analyzePlugins)
{
    plugin.Analyze(textForAnalysis);
    Console.WriteLine($"Plugin: {plugin.Name}");
    Console.WriteLine($"Description: {plugin.Description}");
    Console.WriteLine("Results:");
    var results = plugin.GetResults();
    foreach (var result in results)
    {
        Console.WriteLine(result);
    }
    Console.WriteLine(new string('-', 50));
}

Console.WriteLine("Editing text:");

var textForEdit = """
                       Document Processing Demo
                  
                  This is the first line.
                  This is the second line.
                  this is the second line.
                  This is the third line.
                  
                  Apple
                  Orange
                  Banana
                  Apple
                  Cherry
                  Banana
                  
                  The quick     brown      fox jumps over     the lazy dog.
                  
                  Programming is fun.
                  Programming is fun.
                  
                  Replace the word "Programming" with "Coding".
                  
                  This line contains extra     spaces.
                  
                  C# is a modern programming language.
                  Java is also a programming language.
                  Python is popular for data science.
                  
                  End of the document.
                  """;

var editorPlugins = new List<IEditorPlugin>
{
    new TextWork.Plugins.TestPlugins.TestEditPlugin(testParameter: "Test parameter")
};

foreach (var plugin in editorPlugins)
{
    plugin.Edit(textForEdit);
    Console.WriteLine($"Plugin: {plugin.Name}");
    Console.WriteLine($"Description: {plugin.Description}");
    Console.WriteLine($"Results:\n{plugin.GetResults()}");
    Console.WriteLine(new string('-', 50));
} 