namespace RayTracer;
public class Colour
{
    public double Red { get; }
    public double Green { get; }
    public double Blue { get; }

    public Colour() : this(0.0, 0.0, 0.0) { }

    public Colour(double red, double green, double blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }

    public override string ToString()
    {
        return $"({Red},{Green},{Blue})";
    }

    private bool IsEqual(Colour colour) =>Equality.Equal(Red, colour.Red) && Equality.Equal(Green, colour.Green) && Equality.Equal(Blue, colour.Blue);

    public override bool Equals(object? obj) => obj is Colour colour && this.IsEqual(colour);

    public override int GetHashCode() => (Red, Green, Blue).GetHashCode();

    public static bool operator ==(Colour colour1, Colour colour2) => colour1.IsEqual(colour2);
    public static bool operator !=(Colour colour1, Colour colour2) => !colour1.IsEqual(colour2);

    public static Colour operator +(Colour colour) => colour;
    public static Colour operator +(Colour colour1, Colour colour2) =>
        new(colour1.Red + colour2.Red, colour1.Green + colour2.Green, colour1.Blue + colour2.Blue);

    public static Colour operator -(Colour colour) => new(-colour.Red, -colour.Green, -colour.Blue);
    public static Colour operator -(Colour colour1, Colour colour2) =>
        new(colour1.Red - colour2.Red, colour1.Green - colour2.Green, colour1.Blue - colour2.Blue);

    public static Colour operator *(Colour colour, double multiplier) =>
        new(colour.Red * multiplier, colour.Green * multiplier, colour.Blue * multiplier);
    public static Colour operator *(Colour colour1, Colour colour2) =>
        new(colour1.Red * colour2.Red, colour1.Green * colour2.Green, colour1.Blue * colour2.Blue);
}