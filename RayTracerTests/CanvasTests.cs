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
                if (canvas.GetPixel(x, y) != black)
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
        canvas.SetPixel(2, 3, red);
        Assert.Equal(red, canvas.GetPixel(2, 3));
    }

    [Fact]
    public void ConstructingThePPMHeader()
    {
        string filename = "PPMHeader.ppm";
        Canvas canvas = new(5, 3);
        canvas.SaveAsPPMHeader(filename, false);
        var lines = Canvas.ReadFromPPM(filename);
        Assert.Equal("P3", lines[0]);
        Assert.Equal("5 3", lines[1]);
        Assert.Equal("255", lines[2]);
    }

    [Fact]
    public void ConstructingPPMPixelData()
    {
        string filename = "PPMBody.ppm";
        Canvas canvas = new(5, 3);
        Colour c1 = new(1.5, 0, 0);
        Colour c2 = new(0, 0.5, 0);
        Colour c3 = new(-0.5, 0, 1);
        canvas.SetPixel(0, 0, c1);
        canvas.SetPixel(2, 1, c2);
        canvas.SetPixel(4, 2, c3);
        canvas.SaveAsPPMBody(filename, false);
        var lines = Canvas.ReadFromPPM(filename);
        Assert.Equal("255 0 0 0 0 0 0 0 0 0 0 0 0 0 0", lines[0]);
        Assert.Equal("0 0 0 0 0 0 0 128 0 0 0 0 0 0 0", lines[1]);
        Assert.Equal("0 0 0 0 0 0 0 0 0 0 0 0 0 0 255", lines[2]);
    }

    [Fact]
    public void SplittingLongLinesInPPMFiles()
    {
        string filename = "PPMBodySplit.ppm";
        Canvas canvas = new(10, 2);
        Colour colour = new(1, 0.8, 0.6);
        for (int x = 0; x < canvas.Width; x++)
        {
            for (int y = 0; y < canvas.Height; y++)
            {
                canvas.SetPixel(x, y, colour);
            }
        }
        canvas.SaveAsPPMBody(filename, false);
        var lines = Canvas.ReadFromPPM(filename);
        Assert.Equal("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204", lines[0]);
        Assert.Equal("153 255 204 153 255 204 153 255 204 153 255 204 153", lines[1]);
        Assert.Equal("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204", lines[2]);
        Assert.Equal("153 255 204 153 255 204 153 255 204 153 255 204 153", lines[3]);
    }

    [Fact]
    public void PPMFilesAreTerminatedByNewlineCharacter()
    {
        string filename = "PPMFooter.ppm";
        Canvas canvas = new(5, 3);
        canvas.SaveAsPPMFooter(filename, false);
        var lines = Canvas.ReadFromPPM(filename);
        Assert.Equal("", lines[0]);
    }
}