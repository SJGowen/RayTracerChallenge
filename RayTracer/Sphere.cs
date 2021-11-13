using System;
using System.Collections.Generic;

namespace RayTracer;

public class Sphere : Shape
{
    public override Intersections Intersects(Ray ray)
    {
        return Discriminant(ray) < 0 ? new Intersections() : LocalIntersects(ray);
    }

    public override Intersections LocalIntersects(Ray ray)
    {
        var sphereToRay = ray.Origin - new RayPoint(0, 0, 0);
        var a = Dot(ray.Direction, ray.Direction);
        var b = 2 * Dot(ray.Direction, sphereToRay);

        var sqrtDiscriminantRay = Math.Sqrt(Discriminant(ray));
        var d1 = (-b - sqrtDiscriminantRay) / (2 * a);
        var d2 = (-b + sqrtDiscriminantRay) / (2 * a);

        Intersection i1 = new(d1, this);
        Intersection i2 = new(d2, this);

        return new Intersections(i1, i2);
    }

    public static double Discriminant(Ray ray)
    {
        var sphereToRay = ray.Origin - new RayPoint(0, 0, 0);
        var a = Dot(ray.Direction, ray.Direction);
        var b = 2 * Dot(ray.Direction, sphereToRay);
        var c = Dot(sphereToRay, sphereToRay) - 1;
        return b * b - 4 * a * c;
    }

    private static double Dot(RayTuple tuple1, RayTuple tuple2)
    {
        return tuple1.Dot(tuple2);
    }
}

