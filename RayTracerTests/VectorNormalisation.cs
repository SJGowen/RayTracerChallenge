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

    [Fact]
    public void NormalisingVector123Gives1DivSqrt14_2DivSqrt14_3DivSqrt14()
    {
        RayVector vector = new(1, 2, 3);
        RayVector actual = RayVector.Normalisation(vector);
        RayVector expected = new(1 / Math.Sqrt(14), 2 / Math.Sqrt(14), 3 / Math.Sqrt(14));
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MagnitudeOfNormalisedVectorEquals1()
    {
        RayVector vector = new(1, 2, 3);
        RayVector norm = RayVector.Normalisation(vector);
        double actual = RayVector.Magnitude(norm);
        Assert.Equal(1, actual);
    }
}

