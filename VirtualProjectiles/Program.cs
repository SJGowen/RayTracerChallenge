using RayTracer;
using System;

namespace VirtualProjectiles;

public class Program
{
    public static void Main()
    {
        //ProjectileTestChapter1();
        ProjectileTestChapter2();
    }

    private static void ProjectileTestChapter2()
    {
        RayPoint start = new(0, 1, 0);
        Canvas canvas = new(1150, 550);
        RayVector gravity = new(0, -0.1, 0);
        RayVector wind = new(-0.01, 0, 0);
        Environment environment = new(gravity, wind);

        double y = 1.8;
        for (int i = 1; i < 8; i++)
        {
            DrawProjectileTrack(canvas, environment, start, y, i);
            y -= 0.2;
        }


        PPMFile.CanvasToPPM(canvas, "Projectile.ppm");
    }

    private static void DrawProjectileTrack(Canvas canvas, Environment environment, RayPoint start, double y, int i)
    {
        var velocity = new RayVector(1, y, 0).Normalise() * 11.25;
        Projectile projectile = new(start, velocity);
        string binary = Convert.ToString(i, 2);
        while (binary.Length < 3) binary = "0" + binary;
        Colour colour = new(binary[0] - '0', binary[1] - '0', binary[2] - '0');
        while (projectile.Position.Y >= 0.0)
        {
            canvas.SetPixel((int)projectile.Position.X, (int)(550 - projectile.Position.Y), colour);
            projectile = Tick(environment, projectile);
        }
    }

    private static void ProjectileTestChapter1()
    {
        for (double deltaX = 0.6; deltaX <= 0.8; deltaX += 0.01)
        {
            for (double deltaY = 0.4; deltaY <= 0.8; deltaY += 0.01)
            {
                Projectile projectile = new(new RayPoint(0, 1, 0), new RayVector(deltaX, deltaY, 0).Normalise());
                Environment environment = new(new RayVector(0, -0.1, 0), new RayVector(-0.01, 0, 0));
                //Console.WriteLine($"Value X={deltaX,4:N2} Y={deltaY,4:N2} gives Verticle Velocity of {projectile.Velocity.X,5:N2} Horizontal Velocity of {projectile.Velocity.Y,5:N2}");
                int ticksInAir = 0;
                while (projectile.Position.Y >= 0.0)
                {
                    //Console.WriteLine($"After tick {ticksInAir,2} projectile is at elevation {projectile.Position.Y,5:N2} and has travelled {projectile.Position.X,8:N5}");
                    ticksInAir++;
                    projectile = Tick(environment, projectile);

                    if (projectile.Position.Y >= 0.0)
                    {
                        Console.WriteLine($"{deltaX,4:N2},{deltaY,4:N2},{ticksInAir},{projectile.Position.Y},{projectile.Position.X}");
                    }
                }

                //Console.WriteLine($"Projectile Travels {projectile.Position.X,8:N5}");
            }
        }
    }

    private static Projectile Tick(Environment world, Projectile projectile)
    {
        return new Projectile(projectile.Position + projectile.Velocity, projectile.Velocity + world.Gravity + world.Wind);
    }
}

