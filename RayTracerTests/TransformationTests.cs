using RayTracer;
using Xunit;

namespace RayTracerTests;

public class TransformationTests
{
    [Fact]
    public void MultiplyingByTranslationMatrix()
    {
        Matrix transform = Matrix.Translation(5, -3, 2);
        RayPoint point = new(-3, 4, 5);
        Assert.Equal(new RayPoint(2, 1, 7), transform * point);
    }
}