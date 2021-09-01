using RayTracer;
using Xunit;

namespace RayTracer_Tests;
public class PointsAndVectors
{
    [Fact]
    public void Tuple_with_W_equal_1_is_Point()
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
    public void Tuple_with_W_equal_0_is_Vector()
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
    public void Point_creates_Tuple_with_W_equal_1()
    {
        RayPoint point = new(4, -4, 3);
        RayTuple tuple = new(4, -4, 3, 1);
        Assert.True(point.IsEqual(tuple));
    }

    [Fact]
    public void Vector_creates_Tuple_with_W_equal_0()
    {
        RayVector vector = new(4, -4, 3);
        RayTuple tuple = new(4, -4, 3, 0);
        Assert.True(vector.IsEqual(tuple));
    }
}
