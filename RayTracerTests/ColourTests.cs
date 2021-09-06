using RayTracer;
using Xunit;

namespace RayTracerTests;

public class ColourTests
{
    [Fact]
    public void ColoursAreRedGreenBlueTuples()
    {
        Colour colour = new(-0.5, 0.4, 1.7);
        Assert.Equal(-0.5, colour.Red);
        Assert.Equal(0.4, colour.Green);
        Assert.Equal(1.7, colour.Blue);
    }

    [Fact]
    public void AddingColours()
    {
        Colour c1 = new(0.9, 0.6, 0.75);
        Colour c2 = new(0.7, 0.1, 0.25);
        Colour actual = c1 + c2;
        Colour expected = new(1.6, 0.7, 1.0);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SubtractingColours()
    {
        Colour c1 = new(0.9, 0.6, 0.75);
        Colour c2 = new(0.7, 0.1, 0.25);
        Colour actual = c1 - c2;
        Colour expected = new(0.2, 0.5, 0.5);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MultiplyingColourByScalar()
    {
        Colour colour = new(0.2, 0.3, 0.4);
        Colour actual = colour * 2;
        Colour expected = new(0.4, 0.6, 0.8);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MultiplyingColours()
    {
        Colour c1 = new(1, 0.2, 0.4);
        Colour c2 = new(0.9, 1, 0.1);
        Colour actual = c1 * c2;
        Colour expected = new(0.9, 0.2, 0.04);
        Assert.Equal(expected, actual);
    }
}

