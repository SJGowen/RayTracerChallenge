namespace RayTracer;

public abstract class Shape
{
    public abstract Intersections Intersects(Ray ray);

    public abstract Intersections LocalIntersects(Ray ray);
}