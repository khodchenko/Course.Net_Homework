namespace OOPClasses;

public class Title
{
    private string _titleName;

    public Title(string titleName= "DEFAULT")
    {
        _titleName = titleName;
    }

    public string TitleName
    {
        get => _titleName;
        set => _titleName = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(TitleName);
    }
}