using RayTracer;
using Xunit;

namespace RayTracerTests;

public class VectorsProducts
{
    [Fact]
    public void DotProductTwoVectorsEqualsSumOfSquaresXYZW()
    {
        RayVector vector1 = new(1, 2, 3);
        RayVector vector2 = new(2, 3, 4);
        double actual = RayVector.DotProduct(vector1, vector2);
    }

    [Fact]
    public void CrossProductTwoVectorsABEqualsVectorC()
    {
        RayVector vector1 = new(1, 2, 3);
        RayVector vector2 = new(2, 3, 4);
        RayVector actual = RayVector.CrossProduct(vector1, vector2);
        RayVector expected = new(-1, 2, -1);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CrossProductTwoVectorsBAEqualsVectorNegC()
    {
        RayVector vector1 = new(1, 2, 3);
        RayVector vector2 = new(2, 3, 4);
        RayVector actual = RayVector.CrossProduct(vector2, vector1);
        RayVector expected = new(1, -2, 1);
        Assert.Equal(expected, actual);
    }
}

