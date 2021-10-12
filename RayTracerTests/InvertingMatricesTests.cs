using RayTracer;
using System;
using Xunit;

namespace RayTracerTests;

public class InvertingMatricesTests
{
    [Fact]
    public void TestingAnInvertibleMatrixForInvertibility()
    {
        Matrix matrix = new(6, 4, 4, 4, 5, 5, 7, 6, 4, -9, 3, -7, 9, 1, 7, -6);
        Assert.NotEqual(0, Matrix.Determinant(matrix));
    }

    [Fact]
    public void TestingANonInvertibleMatrixForInvertibility()
    {
        Matrix matrix = new(-4, 2, -2, -3, 9, 6, 2, 6, 0, -5, 1, -5, 0, 0, 0, 0);
        Assert.Equal(0, Matrix.Determinant(matrix));
    }
}
