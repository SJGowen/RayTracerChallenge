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
}