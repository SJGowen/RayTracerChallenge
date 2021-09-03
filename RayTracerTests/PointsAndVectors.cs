using RayTracer;
using Xunit;

namespace RayTracerTests;
public class PointsAndVectors
{
    [Fact]
    public void TupleWithWEqual1IsPoint()
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
    public void TupleWithWEqual0IsVector()
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
    public void PointCreatesTupleWithWEqual1()
    {
        RayPoint point = new(4, -4, 3);
        RayTuple tuple = new(4, -4, 3, 1);
        Assert.True(point.IsEqual(tuple));
    }

    [Fact]
    public void VectorCreatesTupleWithWEqual0()
    {
        RayVector vector = new(4, -4, 3);
        RayTuple tuple = new(4, -4, 3, 0);
        Assert.True(vector.IsEqual(tuple));
    }
}
