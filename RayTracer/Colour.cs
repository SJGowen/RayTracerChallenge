using System;

namespace RayTracer;

public class Colour
{
    public Colour(double red, double green, double blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }

    public double Red { get; }
    public double Green { get; }
    public double Blue { get; }

    private const double Epsilon = 0.00001;
    public static bool Equal(double a, double b) => Math.Abs(a - b) <= Epsilon;
    public static bool Equal(int a, int b) => Math.Abs(a - b) <= Epsilon;

    public bool IsEqual(object? obj) => obj is Colour colour && Equal(Red, colour.Red) && Equal(Green, colour.Green) && Equal(Blue, colour.Blue);

    public override bool Equals(object? obj) => obj is Colour colour && this.IsEqual(colour);

    public override int GetHashCode() => (Red, Green, Blue).GetHashCode();

    public static bool operator ==(Colour colour1, Colour colour2) => colour1.IsEqual(colour2);
    public static bool operator !=(Colour colour1, Colour colour2) => !colour1.IsEqual(colour2);

    public static Colour operator +(Colour colour) => colour;
    public static Colour operator +(Colour colour1, Colour colour2) =>
        new(colour1.Red + colour2.Red, colour1.Green + colour2.Green, colour1.Blue + colour2.Blue);
}