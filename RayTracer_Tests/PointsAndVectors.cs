using Xunit;

namespace RayTracer_Tests;
public class PointsAndVectors
{
    [Fact]
    public void A_Tuple_with_W_equal_1_is_a_Point()
    {
        RayTuple tuple = new(4.3, -4.2, 3.1, 1.0);
        Assert.Equal(4.3, tuple.X);
        Assert.Equal(-4.2, tuple.Y);
        Assert.Equal(3.1, tuple.Z);
        Assert.Equal(1.0, tuple.W);
        Assert.True(tuple.IsPoint);
        Assert.False(tuple.IsVector);
    }

    [Fact]
    public void A_Tuple_with_W_equal_0_is_a_Vector()
    {
        RayTuple tuple = new(4.3, -4.2, 3.1, 0.0);
        Assert.Equal(4.3, tuple.X);
        Assert.Equal(-4.2, tuple.Y);
        Assert.Equal(3.1, tuple.Z);
        Assert.Equal(0.0, tuple.W);
        Assert.False(tuple.IsPoint);
        Assert.True(tuple.IsVector);
    }
}

public class RayTuple
{
    public RayTuple(double x, double y, double z, double w)
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
}