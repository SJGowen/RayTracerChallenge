using RayTracer;
using Xunit;

namespace RayTracerTests;
public class CanvasTests
{
    [Fact]
    public void CreatingCanvas()
    {
        Canvas canvas = new(10, 20);

        Colour black = new(0, 0, 0);
        bool isBlack = true;
        for (int x = 0; x < canvas.Width; x++)
        {
            for (int y = 0; y < canvas.Height; y++)
            {
                if (canvas.Pixels[x, y] != black)
                    isBlack = false;
            }
        }

        Assert.Equal(10, canvas.Width);
        Assert.Equal(20, canvas.Height);
        Assert.True(isBlack);
    }

    [Fact]
    public void WritingPixelToCanvas()
    {
        Canvas canvas = new(10, 20);
        Colour red = new(1, 0, 0);
        canvas.Pixels[2, 3] = red;
        Assert.Equal(red, canvas.Pixels[2, 3]);
    }

    [Fact]
    public void ConstructingThePPMHeader()
    {
        String filename = "ConstructingThePPMHeader.ppm";
        Canvas canvas = new(5, 3);
        canvas.SaveAsPPM(filename);
        var lines = Canvas.ReadFromPPM(filename);
        Assert.Equal("P3", lines[0]);
        Assert.Equal("5 3", lines[1]);
        Assert.Equal("255", lines[2]);
    }
}