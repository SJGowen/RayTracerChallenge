using RayTracer;

namespace VirtualProjectiles;

internal class Projectile
{
    public RayTuple Position { get; }
    public RayTuple Velocity { get; }

    public Projectile(RayTuple position, RayTuple velocity)
    {
        Position = position;
        Velocity = velocity;
    }
}

internal class World
{
    public RayVector Gravity { get; }
    public RayVector Wind { get; }

    public World(RayVector gravity, RayVector wind)
    {
        Gravity = gravity;
        Wind = wind;
    }
}

public class Program
{
    public static void Main()
    {
        for (double deltaX = 0.6; deltaX <= 0.8; deltaX += 0.01)
        {
            for (double deltaY = 0.4; deltaY <= 0.8; deltaY += 0.01)
            {
                Projectile projectile = new(new RayPoint(0, 1, 0), RayVector.Normalisation(new RayVector(deltaX, deltaY, 0)));
                World world = new(new RayVector(0, -0.1, 0), new RayVector(-0.01, 0, 0));
                //Console.WriteLine($"Value X={deltaX,4:N2} Y={deltaY,4:N2} gives Verticle Velocity of {projectile.Velocity.X,5:N2} Horizontal Velocity of {projectile.Velocity.Y,5:N2}");
                int ticksInAir = 0;
                while (projectile.Position.Y >= 0.0)
                {
                    //Console.WriteLine($"After tick {ticksInAir,2} projectile is at elevation {projectile.Position.Y,5:N2} and has travelled {projectile.Position.X,8:N5}");
                    ticksInAir++;
                    projectile = Tick(world, projectile);

                    if (projectile.Position.Y >= 0.0)
                    {
                        Console.WriteLine($"{deltaX,4:N2},{deltaY,4:N2},{ticksInAir},{projectile.Position.Y},{projectile.Position.X}");
                    }
                }

                //Console.WriteLine($"Projectile Travels {projectile.Position.X,8:N5}");
            }
        }
    }

    private static Projectile Tick(World world, Projectile projectile)
    {
        return new Projectile(projectile.Position + projectile.Velocity, projectile.Velocity + world.Gravity + world.Wind);
    }
}

