namespace RayTracer;

public class Intersection
{
    public double Distance { get;  }
    public Shape Shape { get; }

    public Intersection(double distance, Shape shape)
    {
        Distance = distance;
        Shape = shape;
    }
}