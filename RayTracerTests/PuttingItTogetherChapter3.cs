using RayTracer;
using System;
using Xunit;

namespace RayTracerTests;

public class PuttingItTogetherChapter3
{
    [Fact]
    public void InvertingIdentityMatrixGivesIdentityMatrix()
    {
        Matrix identityMatrix = new(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        Matrix inversedIdentityMatrix = Matrix.Inverse(identityMatrix);
        Assert.Equal(identityMatrix, inversedIdentityMatrix);
    }

    [Fact]
    public void MultiplyingMatrixByItsInverseGivesIdentityMatrix()
    {
        Matrix identityMatrix = new(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        Matrix matrix = new(6, 4, 4, 4, 5, 5, 7, 6, 4, -9, 3, -7, 9, 1, 7, -6);
        Matrix inverseMatrix = Matrix.Inverse(matrix);
        Assert.Equal(identityMatrix, matrix * inverseMatrix);
    }

    [Fact]
    public void InverseTransposeVsTransposeInverseEqualsNoDifference()
    {
        Matrix matrix = new(6, 4, 4, 4, 5, 5, 7, 6, 4, -9, 3, -7, 9, 1, 7, -6);
        Assert.Equal(Matrix.Inverse(Matrix.Transpose(matrix)), Matrix.Transpose(Matrix.Inverse(matrix)));
    }

    [Fact]
    public void MultiplyingIdentityMatrixWithOneElementChanged()
    {
        Matrix identityMatrixOneElementChanged = new(1, 0, 0, (1), 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        RayTuple rayTuple = new(1, 2, 3, 4);
        var actual = identityMatrixOneElementChanged * rayTuple;
        // actual = Column * Digit + (Raytuple for Row)
        RayTuple expected = new(5, 2, 3, 4);
        Assert.Equal(expected, actual);
    }
}