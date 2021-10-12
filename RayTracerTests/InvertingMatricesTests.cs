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
}
