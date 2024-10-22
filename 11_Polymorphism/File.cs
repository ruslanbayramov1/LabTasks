namespace _11_Polymorphism;

internal class Word : ITextEditor
{
    private string _currentText;
    public string CurrentText { get { return _currentText; } }

    public void Open()
    {
        _currentText = "";
    }

    public void Save()
    {
        Console.WriteLine(CurrentText);
    }

    public void SaveAndClose(string fileName)
    {
        Console.WriteLine($"C:/Users/Word/{fileName}.docx");
    }

    public void Write(string text)
    {
        _currentText += text;
    }
}

internal class Notepad : ITextEditor
{
    private string _currentText;
    public string CurrentText { get { return _currentText; } }

    public void Open()
    {
        _currentText = "";
    }

    public void Save()
    {
        Console.WriteLine(CurrentText);
    }

    public void SaveAndClose(string fileName)
    {
        Console.WriteLine($"C:/Users/Desktop/{fileName}.txt");
    }

    public void Write(string text)
    {
        _currentText += text;
    }
}

internal class WordPad : ITextEditor
{
    private string _currentText;
    public string CurrentText { get { return _currentText; } }

    public void Open()
    {
        _currentText = "";
    }

    public void Save()
    {
        Console.WriteLine(CurrentText);
    }

    public void SaveAndClose(string fileName)
    {
        Console.WriteLine($"C:/Users/Documents/{fileName}.txt");
    }

    public void Write(string text)
    {
        _currentText += text;
    }
}
