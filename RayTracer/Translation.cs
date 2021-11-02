namespace RayTracer;

public class Translation : RayTuple
{
    public Translation(double x, double y, double z) : base(x, y, z, 0) { }

    public static Translation Inverse(Translation transform) =>
        new(-transform.X, -transform.Y, -transform.Z);

    public static RayPoint operator *(Translation transform, RayPoint point)
    {
        return new RayPoint(transform.X + point.X, transform.Y + point.Y, transform.Z + point.Z);
    }

    public static RayVector operator *(Translation transform, RayVector vector)
    {
        return new RayVector(vector.X, vector.Y, vector.Z);
    }
}
