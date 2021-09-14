using RayTracer;
using Xunit;

namespace RayTracerTests;

public class MatrixTests
{
    [Fact]
    public void ConstructAndInspect4x4Matrix()
    {
        Matrix matrix = new(4, 4);
        matrix.Add(1, 2, 3, 4, 5.5, 6.5, 7.5, 8.5, 9, 10, 11, 12, 13.5, 14.5, 15.5, 16.5);
        Assert.Equal(1, matrix.Cells[0, 0]);
        Assert.Equal(4, matrix.Cells[0, 3]);
        Assert.Equal(5.5, matrix.Cells[1, 0]);
        Assert.Equal(7.5, matrix.Cells[1, 2]);
        Assert.Equal(11, matrix.Cells[2, 2]);
        Assert.Equal(13.5, matrix.Cells[3, 0]);
        Assert.Equal(15.5, matrix.Cells[3, 2]);
    }

    [Fact]
    public void A2x2MatrixIsRepresentable()
    {
        Matrix matrix = new(2, 2);
        matrix.Add(-3, 5, 1, -2);
        Assert.Equal(-3, matrix.Cells[0, 0]);
        Assert.Equal(5, matrix.Cells[0, 1]);
        Assert.Equal(1, matrix.Cells[1, 0]);
        Assert.Equal(-2, matrix.Cells[1, 1]);
    }

    [Fact]
    public void A3x3MatrixIsRepresentable()
    {
        Matrix matrix = new(3, 3);
        matrix.Add(-3, 5, 0, 1, -2, -7, 0, 1, 1);
        Assert.Equal(-3, matrix.Cells[0, 0]);
        Assert.Equal(-2, matrix.Cells[1, 1]);
        Assert.Equal(1, matrix.Cells[2, 2]);
    }

    [Fact]
    public void MatrixEqualityWithIdenticalMatrices()
    {
        Matrix matrixA = new(4, 4);
        matrixA.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
        Matrix matrixB = new(4, 4);
        matrixB.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
        Assert.Equal(matrixA, matrixB);
    }

    [Fact]
    public void MatrixEqualityWithDifferentMatrices()
    {
        Matrix matrixA = new(4, 4);
        matrixA.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
        Matrix matrixB = new(4, 4);
        matrixB.Add(2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2, 1);
        Assert.NotEqual(matrixA, matrixB);
    }

    [Fact]
    public void MultiplyTwo4x4Matrices()
    {
        Matrix matrixA = new(4, 4);
        matrixA.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
        Matrix matrixB = new(4, 4);
        matrixB.Add(-2, 1, 2, 3, 3, 2, 1, -1, 4, 3, 6, 5, 1, 2, 7, 8);
        Matrix expected = new(4, 4);
        expected.Add(20, 22, 50, 48, 44, 54, 114, 108, 40, 58, 110, 102, 16, 26, 46, 42);
        Matrix actual = matrixA * matrixB;
        Assert.Equal(expected, actual);
    }
}
