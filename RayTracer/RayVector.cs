namespace RayTracer;
public class RayVector : RayTuple
{
    public RayVector(double x, double y, double z) : base(x, y, z, 0.0) { }
    public RayVector(int x, int y, int z) : base(x, y, z, 0) { }

    public static double Magnitude(RayVector vector) =>
        Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z + vector.W * vector.W);

    public static RayVector Normalisation(RayVector vector) => 
        new(vector.X / Magnitude(vector), vector.Y / Magnitude(vector), vector.Z / Magnitude(vector));

    public static double DotProduct(RayVector vector1, RayVector vector2) =>
        vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z + vector1.W * vector2.W;
}
