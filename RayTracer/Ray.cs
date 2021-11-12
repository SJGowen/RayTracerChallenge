namespace RayTracer;

public class Ray
{
    public RayPoint Origin { get; }
    public RayVector Direction { get; }

    public Ray(RayPoint origin, RayVector direction)
    {
        Origin = origin;
        Direction = direction;
    }

    public RayTuple Position(double t)
    {
        return Origin + Direction * t;
    }
}
