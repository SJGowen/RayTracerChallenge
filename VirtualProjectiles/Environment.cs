using RayTracer;

namespace VirtualProjectiles;

public class Environment
{
    public RayVector Gravity { get; }
    public RayVector Wind { get; }

    public Environment(RayVector gravity, RayVector wind)
    {
        Gravity = gravity;
        Wind = wind;
    }
}

