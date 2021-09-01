using RayTracer;
using Xunit;

namespace RayTracer_Tests;
public class PointsAndVectorsMaths
{
    [Fact]
    public void Adding_two_Tuples()
    {
        RayTuple tuple1 = new(3, -2, 5, 1);
        RayTuple tuple2 = new(-2, 3, 1, 0);
        RayTuple actual = tuple1 + tuple2;
        RayTuple expected = new(1, 1, 6, 1);
        Assert.Equal(expected, actual);
    }
}
