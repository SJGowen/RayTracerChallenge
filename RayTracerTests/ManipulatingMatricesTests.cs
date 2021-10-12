using Newtonsoft.Json.Linq;
using RayTracer;
using System;
using Xunit;

namespace RayTracerTests;

public class ManipulatingMatricesTests
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

    [Fact]
    public void SubmatrixOf4x4MatrixIs3x3Matrix()
    {
        Matrix matrix = new(-6, 1, 1, 6, -8, 5, 8, 6, -1, 0, 8, 2, -7, 1, -1, 1);
        var actual = Matrix.SubMatrix(matrix, 2, 1);
        Matrix expected = new(-6, 1, 6, -8, 8, 6, -7, -1, 1);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SubmatrixWhenCalledWithHighRowValueThrowsException()
    {
        Matrix matrix = new(1, 5, 0, -3, 2, 7, 0, 6, -3);
        var caughtException = Assert.Throws<ArgumentException>(() => Matrix.SubMatrix(matrix, 3, 0));
        Assert.Equal("Value of argument row is greater than the number of rows in the Matrix", caughtException.Message);
    }

    [Fact]
    public void SubmatrixWhenCalledWithHighColumnValueThrowsException()
    {
        Matrix matrix = new(1, 5, 0, -3, 2, 7, 0, 6, -3);
        var caughtException = Assert.Throws<ArgumentException>(() => Matrix.SubMatrix(matrix, 0, 3));
        Assert.Equal("Value of argument col is greater than the number of columns in the Matrix", caughtException.Message);
    }

    [Fact]
    public void CalculatingMinorOf3x3Matrix()
    {
        Matrix matrix = new(3, 5, 0, 2, -1, -7, 6, -1, 5);
        Matrix matrixB = Matrix.SubMatrix(matrix, 1, 0);
        Assert.Equal(25, Matrix.Determinant(matrixB));
        Assert.Equal(25, Matrix.Minor(matrix, 1, 0));
    }
}
