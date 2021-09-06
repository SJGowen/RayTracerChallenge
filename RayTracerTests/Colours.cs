using RayTracer;
using Xunit;

namespace RayTracerTests;

public class Colours
{
    [Fact]
    public void ColoursAreRedGreenBlueTuples()
    {
        Colour colour = new(-0.5, 0.4, 1.7);
        Assert.Equal(-0.5, colour.Red);
        Assert.Equal(0.4, colour.Green);
        Assert.Equal(1.7, colour.Blue);
    }
}

