using RayTracer;
using Xunit;

namespace RayTracerTests;

public class MatrixTests
{
    [Fact]
    public void ConstructingAndInspecting4x4Matrix()
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
}

