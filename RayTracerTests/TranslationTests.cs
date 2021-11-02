using RayTracer;
using Xunit;

namespace RayTracerTests;

public class TranslationTests
{
    [Fact]
    public void MultiplyingByTranslationMatrix()
    {
        Translation transform = new(5, -3, 2);
        RayPoint point = new(-3, 4, 5);
        var actual = transform * point;
        RayPoint expected = new(2, 1, 7);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MultiplyingByTheInverseTranslationMatrix()
    {
        Translation transform = new(5, -3, 2);
        var inv = Translation.Inverse(transform);
        RayPoint point = new(-3, 4, 5);
        RayPoint actual = inv * point;
        RayPoint expected = new(-8, 7, 3);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TranslationDoesNotAffectVectors()
    {
        Translation transform = new(5, -3, 2);
        RayVector vector = new(-3, 4, 5);
        RayVector actual = transform * vector;
        Assert.Equal(vector, actual);
    }
}
