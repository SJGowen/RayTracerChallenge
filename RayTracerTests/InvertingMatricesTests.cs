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

    [Fact]
    public void CalculatingTheInverseOfMatrix()
    {
        Matrix matrix = new(-5, 2, 6, -8, 1, -5, 1, 8, 7, 7, -6, -7, 1, -3, 7, 4);
        var actual = Matrix.Inverse(matrix);
        Assert.Equal(532, Matrix.Determinant(matrix));
        Assert.Equal(-160, Matrix.Cofactor(matrix, 2, 3));
        Assert.Equal(-160.0 / 532.0, actual.Cells[3, 2]);
        Assert.Equal(105, Matrix.Cofactor(matrix, 3, 2));
        Assert.Equal(105.0 / 532.0, actual.Cells[2, 3]);
        Matrix expected = new(0.21805, 0.45113, 0.24060, -0.04511, -0.80827, -1.45677, -0.44361, 0.52068, -0.07895, -0.22368, -0.05263, 0.19737, -0.52256, -0.81391, -0.30075, 0.30639);
        Assert.Equal(expected, actual);
    }
}
