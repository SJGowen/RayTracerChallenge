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
}