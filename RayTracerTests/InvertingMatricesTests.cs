using RayTracer;
using System;
using Xunit;

namespace RayTracerTests;

public class InvertingMatricesTests
{
    [Fact]
    public void CalculatingDeterminant2x2Matrix()
    {
        Matrix matrix = new(1, 5, -3, 2);
        var actual = Matrix.Determinant(matrix);
        Assert.Equal(17.0, actual);
    }
}
