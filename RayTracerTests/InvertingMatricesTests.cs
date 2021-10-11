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

    [Fact]
    public void SubmatrixOf3x3MatrixIs2x2Matrix()
    {
        Matrix matrix = new(1, 5, 0, -3, 2, 7, 0, 6, -3);
        var actual = Matrix.SubMatrix(matrix, 0, 2);
        Matrix expected = new(-3, 2, 0, 6);
        Assert.Equal(expected, actual);
    }
}
