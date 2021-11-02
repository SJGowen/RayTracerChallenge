namespace RayTracer;

public class Scaling : RayTuple
{
    public Scaling(double x, double y, double z) : base(x, y, z, 0) { }

    public static RayPoint operator *(Scaling transform, RayPoint point)
    {
        return new RayPoint(transform.X * point.X, transform.Y * point.Y, transform.Z * point.Z);
    }
}