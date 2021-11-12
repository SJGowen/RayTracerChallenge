using RayTracer;
using Xunit;

namespace RayTracerTests;

public class RaySphereIntersectionsTests
{
    [Fact]
    public void CreatingAndQueryingARay()
    {
        RayPoint origin = new(1, 2, 3);
        RayVector direction = new(4, 5, 6);
        Ray ray = new(origin, direction);

        Assert.Equal(origin, ray.Origin);
        Assert.Equal(direction, ray.Direction);
    }
}

