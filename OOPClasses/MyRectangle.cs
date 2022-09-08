namespace OOPClasses;

public class MyRectangle
{
    public MyRectangle(double side1, double side2)
    {
        this.side1 = side1;
        this.side2 = side2;
    }

    public override string ToString()
    {
        return $"{Perimeter} {Square}";
    }

    private double side1;
    private double side2;

    public double Side1
    {
        get => side1;
        set => side1 = value;
    }

    public double Side2
    {
        get => side2;
        set => side2 = value;
    }

    public double Square
    {
        get => side1*side2;
    }

    public double Perimeter
    {
        get => (side1 + side2) * 2;
    }
}