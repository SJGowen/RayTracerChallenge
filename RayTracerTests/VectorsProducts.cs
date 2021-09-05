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
}

