namespace OOPClasses;

public class Figure
{
    private string _name;
    private double _perimeter;
    private Point[] _points;

    public double Perimeter
    {
        set => _perimeter = value;
        get
        {
            PerimeterCalculator();
            return _perimeter;
        }
    }

    public override string ToString()
    {
        return $"{_name} perimeter={_perimeter}";
    }

    public Figure(Point[] points, string name = "DefaultFigureName")
    {
        _points = points;
        _name = name;
    }

    public double LengthSide(Point A, Point B)
    {
        var temp = (B.Y - A.Y) ^ 2 + (B.X - A.X) ^ 2;
        return Math.Sqrt(temp);
    }

    public void PerimeterCalculator()
    {
        if (_points.Length == 4)
        {
            var side1 = LengthSide(_points[0], _points[1]);
            var side2 = LengthSide(_points[2], _points[3]);

            Perimeter = (side1 + side2) * 2;
        }
    }
}