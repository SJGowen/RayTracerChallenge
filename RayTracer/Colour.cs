namespace RayTracer;
public class Colour
{
    public double Red { get; }
    public double Green { get; }
    public double Blue { get; }

    public Colour() : this(0.0, 0.0, 0.0) { }

    public Colour(int red, int green, int blue) : this(red * 1.0, green * 1.0, blue * 1.0) { }

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

    public string ToPPMString()
    {
        return $"{Normalise(Red)} {Normalise(Green)} {Normalise(Blue)}";
    }

    private static string Normalise(double colour)
    {
        int normalised = (int)(colour * 256);
        if (normalised < 0) normalised = 0;
        if (normalised > 255) normalised = 255;
        return $"{normalised}";
    }

    public bool IsEqual(object? obj) => obj is Colour colour && Equality.Equal(Red, colour.Red) && Equality.Equal(Green, colour.Green) && Equality.Equal(Blue, colour.Blue);

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