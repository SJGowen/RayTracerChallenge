﻿using RayTracer;
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

    [Fact]
    public void CalculatingTheInverseOfAnotherMatix()
    {
        Matrix matrix = new(8, -5, 9, 2, 7, 5, 6, 1, -6, 0, 9, 6, -3, 0, -9, -4);
        var actual = Matrix.Inverse(matrix);
        Matrix expected = new(-0.15385, -0.15385, -0.28205, -0.53846, -0.07692, 0.12308, 0.02564, 0.03077, 0.35897, 0.35897, 0.43590, 0.92308, -0.69231, -0.69231, -0.76923, -1.92308);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculatingTheInverseOfThirdMatrix()
    {
        Matrix matrix = new(9, 3, 0, 9, -5, -2, -6, -3, -4, 9, 6, 4, -7, 6, 6, 2);
        var actual = Matrix.Inverse(matrix);
        Matrix expected = new(-0.04074, -0.07778, 0.14444, -0.22222, -0.07778, 0.03333, 0.36667, -0.33333, -0.02901, -0.14630, -0.10926, 0.12963, 0.17778, 0.06667, -0.26667, 0.33333);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MultiplyingProductByItsInverse()
    {
        Matrix matrixA = new(3, -9, 7, 3, 3, -8, 2, -9, -4, 4, 4, 1, -6, 5, -1, 1);
        Matrix matrixB = new(8, 2, 2, 2, 3, -1, 7, 0, 7, 0, 5, 4, 6, -2, 0, 5);
        Matrix matrixC = matrixA * matrixB;
        Assert.Equal(matrixA, matrixC * Matrix.Inverse(matrixB));
    }
}
