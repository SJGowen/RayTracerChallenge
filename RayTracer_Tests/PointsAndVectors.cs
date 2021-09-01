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

    [Fact]
    public void A_Point_creates_Tuple_with_W_equal_1()
    {
        RayPoint point = new(4, -4, 3);
        RayTuple tuple = new(4, -4, 3, 1);
        Assert.True(point.IsEqual(tuple));
    }

    [Fact]
    public void A_Vector_creates_Tuple_with_W_equal_0()
    {
        RayVector vector = new(4, -4, 3);
        RayTuple tuple = new(4, -4, 3, 0);
        Assert.True(vector.IsEqual(tuple));
    }
}

public class RayVector : RayTuple
{
    public RayVector(double x, double y, double z) : base(x, y, z, 0.0) { }
    public RayVector(int x, int y, int z) : base(x, y, z, 0) { }
}

public class RayPoint : RayTuple
{
    public RayPoint(double x, double y, double z) : base(x, y, z, 1.0) { }
    public RayPoint(int x, int y, int z) : base(x, y, z, 1) { }
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