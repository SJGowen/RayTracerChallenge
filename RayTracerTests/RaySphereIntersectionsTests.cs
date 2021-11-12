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

    [Fact]
    public void ComputingAPointFromADistance()
    {
        Ray ray = new(new RayPoint(2, 3, 4), new RayVector(1, 0, 0));
        Assert.Equal(new RayPoint(2, 3, 4), ray.Position(0));
        Assert.Equal(new RayPoint(3, 3, 4), ray.Position(1));
        Assert.Equal(new RayPoint(1, 3, 4), ray.Position(-1));
        Assert.Equal(new RayPoint(4.5, 3, 4), ray.Position(2.5));
    }
}

