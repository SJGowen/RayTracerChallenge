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

    private const double Epsilon = 0.00001;
    public static bool Equal(double a, double b) => Math.Abs(a - b) <= Epsilon;
    public static bool Equal(int a, int b) => Math.Abs(a - b) <= Epsilon;

    public bool IsEqual(RayTuple tuple) => Equal(X, tuple.X) && Equal(Y, tuple.Y) && Equal(Z, tuple.Z) && Equal(W, tuple.W);
}