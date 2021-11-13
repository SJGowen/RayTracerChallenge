using RayTracer;
using System.Collections.Generic;
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

    [Fact]
    public void ARayIntersectsASphereAtTwoPoints()
    {
        Ray ray = new(new RayPoint(0, 0, -5), new RayVector(0, 0, 1));
        Sphere sphere = new();
        List<double> intersects = sphere.Intersects(ray);
        Assert.Equal(2, intersects.Count);
        Assert.Equal(4.0, intersects[0]);
        Assert.Equal(6.0, intersects[1]);
    }

    [Fact]
    public void ARayIntersectsASphereAtATangent()
    {
        Ray ray = new(new RayPoint(0, 1, -5), new RayVector(0, 0, 1));
        Sphere sphere = new();
        List<double> intersects = sphere.Intersects(ray);
        Assert.Equal(2, intersects.Count);
        Assert.Equal(5.0, intersects[0]);
        Assert.Equal(5.0, intersects[1]);
    }

    [Fact]
    public void ARayMissesASphere()
    {
        Ray ray = new(new RayPoint(0, 2, -5), new RayVector(0, 0, 1));
        Sphere sphere = new();
        List<double> intersects = sphere.Intersects(ray);
        Assert.Empty(intersects);
    }

    [Fact]
    public void ARayOriginatesInsideASphere()
    {
        Ray ray = new(new RayPoint(0, 0, 0), new RayVector(0, 0, 1));
        Sphere sphere = new();
        List<double> intersects = sphere.Intersects(ray);
        Assert.Equal(2, intersects.Count);
        Assert.Equal(-1.0, intersects[0]);
        Assert.Equal(1.0, intersects[1]);
    }

    [Fact]
    public void ASphereIsBehindARay()
    {
        Ray ray = new(new RayPoint(0, 0, 5), new RayVector(0, 0, 1));
        Sphere sphere = new();
        List<double> intersects = sphere.Intersects(ray);
        Assert.Equal(2, intersects.Count);
        Assert.Equal(-6.0, intersects[0]);
        Assert.Equal(-4.0, intersects[1]);
    }
}

