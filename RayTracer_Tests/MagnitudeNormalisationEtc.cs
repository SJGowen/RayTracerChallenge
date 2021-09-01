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
}
