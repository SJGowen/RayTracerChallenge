using RayTracer;
using Xunit;

namespace RayTracerTests;

public class VectorNormalisation
{
    [Fact]
    public void NormalisingVector400Gives100()
    {
        RayVector vector = new(4, 0, 0);
        RayVector actual = RayVector.Normalisation(vector);
        RayVector expected = new(1, 0, 0);
        Assert.Equal(expected, actual);
    }
}

