namespace OOPClasses;

public class Author
{
    private string _authorName;

    public Author(string authorName = "DEFAULT")
    {
        _authorName = authorName;
    }

    public string AuthorName
    {
        get => _authorName;
        set => _authorName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(AuthorName);
    }
}