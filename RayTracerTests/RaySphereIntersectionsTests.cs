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
        Intersections xs = sphere.Intersects(ray);
        Assert.Equal(2, xs.Intersects.Count);
        Assert.Equal(4.0, xs.Intersects[0].Distance);
        Assert.Equal(6.0, xs.Intersects[1].Distance);
    }

    [Fact]
    public void ARayIntersectsASphereAtATangent()
    {
        Ray ray = new(new RayPoint(0, 1, -5), new RayVector(0, 0, 1));
        Sphere sphere = new();
        Intersections xs = sphere.Intersects(ray);
        Assert.Equal(2, xs.Intersects.Count);
        Assert.Equal(5.0, xs.Intersects[0].Distance);
        Assert.Equal(5.0, xs.Intersects[1].Distance);
    }

    [Fact]
    public void ARayMissesASphere()
    {
        Ray ray = new(new RayPoint(0, 2, -5), new RayVector(0, 0, 1));
        Sphere sphere = new();
        Intersections xs = sphere.Intersects(ray);
        Assert.Empty(xs.Intersects);
    }

    [Fact]
    public void ARayOriginatesInsideASphere()
    {
        Ray ray = new(new RayPoint(0, 0, 0), new RayVector(0, 0, 1));
        Sphere sphere = new();
        Intersections xs = sphere.Intersects(ray);
        Assert.Equal(2, xs.Intersects.Count);
        Assert.Equal(-1.0, xs.Intersects[0].Distance);
        Assert.Equal(1.0, xs.Intersects[1].Distance);
    }

    [Fact]
    public void ASphereIsBehindARay()
    {
        Ray ray = new(new RayPoint(0, 0, 5), new RayVector(0, 0, 1));
        Sphere sphere = new();
        Intersections xs = sphere.Intersects(ray);
        Assert.Equal(2, xs.Intersects.Count);
        Assert.Equal(-6.0, xs.Intersects[0].Distance);
        Assert.Equal(-4.0, xs.Intersects[1].Distance);
    }

    [Fact]
    public void AnIntersectionEncapsulatesTAndObject()
    {
        Sphere sphere = new();
        Intersection i1 = new(3.5, sphere);
        Assert.Equal(3.5, i1.Distance);
        Assert.Equal(sphere, i1.Shape);
    }

    [Fact]
    public void AggregatingIntersections()
    {
        Sphere sphere = new();
        Intersection i1 = new(1, sphere);
        Intersection i2 = new(2, sphere);
        Intersections xs = new(i1, i2);
        Assert.Equal(2, xs.Intersects.Count);
        Assert.Equal(1, xs.Intersects[0].Distance);
        Assert.Equal(2, xs.Intersects[1].Distance);
    }

    [Fact]
    public void IntersectSetsTheObjectOnTheIntersection()
    {
        Ray ray = new(new RayPoint(0, 0, -5), new RayVector(0, 0, 1));
        Sphere sphere = new();
        var xs = sphere.Intersects(ray);
        Assert.Equal(2, xs.Intersects.Count);
        Assert.Equal(sphere, xs.Intersects[0].Shape);
        Assert.Equal(sphere, xs.Intersects[1].Shape);
    }
}

