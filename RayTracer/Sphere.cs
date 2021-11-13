using System;
using System.Collections.Generic;

namespace RayTracer;

public class Sphere
{
    public Sphere()
    {
    }

    public List<double> Intersects(Ray ray)
    {
        return Discriminant(ray) < 0 ? new List<double>() : LocalIntersects(ray);
    }

    private static List<double> LocalIntersects(Ray ray)
    {
        var sphereToRay = ray.Origin - new RayPoint(0, 0, 0);
        var a = Dot(ray.Direction, ray.Direction);
        var b = 2 * Dot(ray.Direction, sphereToRay);
        List<double> result = new();
        result.Add((-b - Math.Sqrt(Discriminant(ray))) / (2 * a));
        result.Add((-b + Math.Sqrt(Discriminant(ray))) / (2 * a));
        result.Sort();
        return result;
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

