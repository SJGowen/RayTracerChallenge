namespace RayTracer;
public class RayPoint : RayTuple
{
    public RayPoint(double x, double y, double z) : base(x, y, z, 1.0) { }
    public RayPoint(int x, int y, int z) : base(x, y, z, 1) { }
}
