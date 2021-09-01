namespace RayTracer;
public class RayVector : RayTuple
{
    public RayVector(double x, double y, double z) : base(x, y, z, 0.0) { }
    public RayVector(int x, int y, int z) : base(x, y, z, 0) { }

    public static double Magnitude(RayVector vector) =>
        Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z + vector.W * vector.W);
}
