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
        var actual = tuple1 + tuple2;
        RayTuple expected = new(1, 1, 6, 1);
        Assert.True(expected.IsEqual(actual));
        Assert.True(expected == actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Subtracting_two_Points()
    {
        RayPoint point1 = new(3, 2, 1);
        RayPoint point2 = new(5, 6, 7);
        var actual = point1 - point2;
        RayVector expected = new(-2, -4, -6);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Subtracting_Vector_from_Point()
    {
        RayPoint point1 = new(3, 2, 1);
        RayVector vector2 = new(5, 6, 7);
        var actual = point1 - vector2;
        RayPoint expected = new(-2, -4, -6);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Subtracting_two_Vectors()
    {
        RayVector vector1 = new(3, 2, 1);
        RayVector vector2 = new(5, 6, 7);
        var actual = vector1 - vector2;
        RayVector expected = new(-2, -4, -6);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Subtracting_Vector_from_the_Zero_Vector()
    {
        RayVector vector1 = new(0, 0, 0);
        RayVector vector2 = new(1, -2, 3);
        var actual = vector1 - vector2;
        RayVector expected = new(-1, 2, -3);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Negating_Tuple()
    {
        RayTuple tuple = new(1, -2, 3, -4);
        var actual = -tuple;
        RayTuple expected = new(-1, 2, -3, 4);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Multiplying_Tuple_by_Scalar()
    {
        RayTuple tuple = new(1, -2, 3, -4);
        var actual = tuple * 3.5;
        RayTuple expected = new(3.5, -7, 10.5, -14);
        Assert.Equal(expected, actual);
    }
}
