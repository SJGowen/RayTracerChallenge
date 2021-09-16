using System;

namespace RayTracer;
public static class Equality
{
    private const double Epsilon = 0.00001;
    public static bool Equal(double a, double b) => Math.Abs(a - b) <= Epsilon;
    public static bool Equal(int a, int b) => Math.Abs(a - b) <= Epsilon;
}
