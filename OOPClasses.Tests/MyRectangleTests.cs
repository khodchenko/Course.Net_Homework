
namespace OOPClasses.Tests;

public  class Tests
{
    
    [TestCase(new[] { 10, 20 })]
    [TestCase(new[] { -10, 20 })]
    public void AddBack_WhenArrayNotEmpty_ShouldAddToBack
        (int[] sourceArray)
    {
        var rectangle = new MyRectangle(sourceArray[0],sourceArray[1]);
        var rectangleTestPerimeter = (sourceArray[0] + sourceArray[1]) * 2;
        var rectangleTestSquare = sourceArray[0] * sourceArray[1];
        
        
        Assert.That(rectangle.Perimeter, Is.EqualTo(rectangleTestPerimeter));
        Assert.That(rectangle.Square, Is.EqualTo(rectangleTestSquare));
        Assert.That(rectangle.ToString(), Is.EqualTo($"{rectangleTestPerimeter} {rectangleTestSquare}"));

    }
}