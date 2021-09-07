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

