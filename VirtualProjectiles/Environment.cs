using RayTracer;

namespace VirtualProjectiles;

internal class Environment
{
    public RayVector Gravity { get; }
    public RayVector Wind { get; }

    public Environment(RayVector gravity, RayVector wind)
    {
        Gravity = gravity;
        Wind = wind;
    }
}

