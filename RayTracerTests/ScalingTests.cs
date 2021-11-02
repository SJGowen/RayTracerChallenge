using RayTracer;
using Xunit;

namespace RayTracerTests;

public class ScalingTests
{
    [Fact]
    public void ScalingMatrixAppliedToPoint()
    {
        Scaling transform = new(2, 3, 4);
        RayPoint point = new(-4, 6, 8);
        RayPoint actual = transform * point;
        RayPoint expected = new(-8, 18, 32);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ScalingMatrixAppliedToVector()
    {
        Scaling transform = new(2, 3, 4);
        RayVector vector = new(-4, 6, 8);
        RayVector actual = transform * vector;
        RayVector expected = new(-8, 18, 32);
    }
}
