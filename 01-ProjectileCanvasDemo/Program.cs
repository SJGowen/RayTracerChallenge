using RayTracer;
using VirtualProjectiles;

namespace _01_ProjectileCanvasDemo;

public class Program
{
    public static void Main()
    {
        RayPoint start = new(0, 1, 0);
        Canvas canvas = new(1150, 550);
        RayVector gravity = new(0, -0.1, 0);
        RayVector wind = new(-0.01, 0, 0);
        VirtualProjectiles.Environment environment = new(gravity, wind);

        double y = 1.8;
        for (int i = 1; i < 8; i++)
        {
            DrawProjectileTrack(canvas, environment, start, y, i);
            y -= 0.2;
        }

        var filename = "Projectile";
        PPMFile.CanvasToPPM(canvas, filename + ".ppm");
        Console.WriteLine($"Flying Projectiles saved in \"{filename}.ppm\"");
    }

    private static void DrawProjectileTrack(Canvas canvas, VirtualProjectiles.Environment environment, RayPoint start, double y, int i)
    {
        var velocity = new RayVector(1, y, 0).Normalise() * 11.25;
        Projectile projectile = new(start, velocity);
        string binary = Convert.ToString(i, 2);
        while (binary.Length < 3) 
            binary = "0" + binary;
        Colour colour = new(binary[0] - '0', binary[1] - '0', binary[2] - '0');
        while (projectile.Position.Y >= 0.0)
        {
            canvas.SetPixel((int)projectile.Position.X, (int)(550 - projectile.Position.Y), colour);
            projectile = Tick(environment, projectile);
        }
    }
    private static Projectile Tick(VirtualProjectiles.Environment world, Projectile projectile)
    {
        return new Projectile(projectile.Position + projectile.Velocity, projectile.Velocity + world.Gravity + world.Wind);
    }
}