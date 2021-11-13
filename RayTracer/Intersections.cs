using System.Collections.Generic;
using System.Linq;

namespace RayTracer;

public class Intersections
{
    public List<Intersection> Intersects { get; }

    public Intersections(params Intersection[] intersections)
    {
        Intersects = intersections.OrderBy(i => i.Distance).ToList();
    }
}
