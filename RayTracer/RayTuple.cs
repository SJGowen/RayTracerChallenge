namespace RayTracer;
public class RayTuple
{
    public RayTuple(double x, double y, double z, double w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public RayTuple(int x, int y, int z, int w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public double X { get; }
    public double Y { get; }
    public double Z { get; }
    public double W { get; }

    public bool IsPoint => W == 1.0;

    public bool IsVector => W == 0.0;

    public bool IsEqual(RayTuple tuple) => X == tuple.X && Y == tuple.Y && Z == tuple.Z && W == tuple.W;
}