namespace _11_Polymorphism;

internal interface ITextEditor
{
    void Open();
    void Write(string text);
    void Save();
    void SaveAndClose(string fileName);
}
