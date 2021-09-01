namespace RayTracer;
public class RayVector : RayTuple
{
    public RayVector(double x, double y, double z) : base(x, y, z, 0.0) { }
    public RayVector(int x, int y, int z) : base(x, y, z, 0) { }
}
