namespace OOPClasses;

public class Book
{
    private string _bookName;

    public Book(string bookName = "DEFAULT")
    {
        _bookName = bookName;
    }

    public string BookName
    {
        get => _bookName;
        set => _bookName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(BookName);
    }
}