using RayTracer;
using System;
using Xunit;

namespace RayTracerTests;
public class VectorMagnitudeTests
{
    [Fact]
    public void MagnitudeOfVector100()
    {
        RayVector vector = new(1, 0, 0);
        var actual = RayVector.Magnitude(vector);
        var expected = 1;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MagnitudeOfVector010()
    {
        RayVector vector = new(0, 1, 0);
        var actual = RayVector.Magnitude(vector);
        var expected = 1;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MagnitudeOfVector001()
    {
        RayVector vector = new(0, 0, 1);
        var actual = RayVector.Magnitude(vector);
        var expected = 1;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MagnitudeOfVector123()
    {
        RayVector vector = new(1, 2, 3);
        var actual = RayVector.Magnitude(vector);
        var expected = Math.Sqrt(14);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MagnitudeOfNegativeVector123()
    {
        RayVector vector = new(-1, -2, -3);
        var actual = RayVector.Magnitude(vector);
        var expected = Math.Sqrt(14);
        Assert.Equal(expected, actual);
    }
}
