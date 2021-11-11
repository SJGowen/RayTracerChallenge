using RayTracer;
using VirtualProjectiles;

namespace _00_ProjectileDemo;

public class Program
{
    public static void Main()
    {
        RayPoint start = new(0, 1, 0);
        RayVector velocity = new(1, 1, 0);
        var projectile = new Projectile(start, velocity.Normalise());

        RayVector gravity = new(0, -0.1, 0);
        RayVector wind = new(-0.01, 0, 0);
        var environment = new VirtualProjectiles.Environment(gravity, wind);

        Console.WriteLine($"Projectile: {projectile.Position}");
        while (projectile.Position.Y >= 0)
        {
            projectile = Tick(environment, projectile);
            Console.WriteLine($"Projectile: {projectile.Position}");
        }
    }

    private static Projectile Tick(VirtualProjectiles.Environment environment, Projectile projectile)
    {
        var position = projectile.Position + projectile.Velocity;
        var velocity = projectile.Velocity + environment.Gravity + environment.Wind;

        return new Projectile(position, velocity);
    }
}