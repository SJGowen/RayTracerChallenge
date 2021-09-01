using RayTracer;
using Xunit;

namespace RayTracer_Tests;
public class MagnitudeNormalisationEtc
{
    [Fact]
    public void Computing_Magnitude_of_Vector_1_0_0()
    {
        RayVector vector = new(1, 0, 0);
        var actual = RayVector.Magnitude(vector);
        var expected = 1;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Computing_Magnitude_of_Vector_0_1_0()
    {
        RayVector vector = new(0, 1, 0);
        var actual = RayVector.Magnitude(vector);
        var expected = 1;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Computing_Magnitude_of_Vector_0_0_1()
    {
        RayVector vector = new(0, 0, 1);
        var actual = RayVector.Magnitude(vector);
        var expected = 1;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Computing_Magnitude_of_Vector_1_2_3()
    {
        RayVector vector = new(1, 2, 3);
        var actual = RayVector.Magnitude(vector);
        var expected = Math.Sqrt(14);
        Assert.Equal(expected, actual);
    }
}
