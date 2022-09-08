namespace OOPClasses;

public class Content
{
    private string _content;

    public Content(string content= "DEFAULT")
    {
        _content = content;
    }

    public string ContentProperty
    {
        get => _content;
        set => _content = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(ContentProperty);
    }
}