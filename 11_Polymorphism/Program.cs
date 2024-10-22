namespace _11_Polymorphism;

internal class Program
{
    static void Main(string[] args)
    {
        ITextEditor[] editors = { new Word(), new Notepad(), new WordPad() };

        foreach (var editor in editors)
        {
            editor.Open();
            editor.Write("Hello guys");
            editor.Save();
            editor.SaveAndClose("myFile");
        }
    }
}
