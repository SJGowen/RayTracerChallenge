using RayTracer;

namespace _02_ClockDemo;

public class Program
{
    public static void Main()
    {
        Canvas canvas = new(1000, 750);
        Colour red = new(1, 0, 0);
        var minDimension = Math.Min(canvas.Width, canvas.Height);
        var scale =  minDimension * 3 / 8;
        var clockCentre = new RayPoint(canvas.Width / 2, minDimension / 2, canvas.Height / 2);
        var step = Math.PI / 6;

        RayPoint twelveOClock = new(0, 0, 1);
        for (int hour = 1; hour <= 12; hour++)
        {
            var rotationY = Matrix.RotationY(hour * step);
            var mark = rotationY * twelveOClock;
            var canvasMark = mark * scale + clockCentre;

            // Console.WriteLine($"ClockHour={hour} Mark={mark} CanvasMark={canvasMark}");
            canvas.SetPixel((int)canvasMark.X, (int)canvasMark.Z, red);
        }

        var filename = "Clock.ppm";
        PPMFile.CanvasToPPM(canvas, filename);
        Console.WriteLine($"Image containing Clock Hours saved in \"{filename}\"");
    }
}
