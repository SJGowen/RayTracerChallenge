using System;

namespace RayTracer;
public class RayTuple
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }
    public double W { get; }

    public RayTuple(double x, double y, double z, double w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    //public override string ToString()
    //{
    //    return $"({X},{Y},{Z},{W})";
    //}

    public override string ToString()
    {
        return $"{Math.Round(X)},{Math.Round(Y)},{Math.Round(Z)},{Math.Round(W)}";
    }

    public bool IsPoint => W == 1.0;

    public bool IsVector => W == 0.0;

    private bool IsEqual(RayTuple tuple) => Equality.Equal(X, tuple.X) && Equality.Equal(Y, tuple.Y) && Equality.Equal(Z, tuple.Z) && Equality.Equal(W, tuple.W);

    public override bool Equals(object? obj) => obj is RayTuple tuple && this.IsEqual(tuple);

    public override int GetHashCode() => (X, Y, Z, W).GetHashCode();

    public static bool operator ==(RayTuple tuple1, RayTuple tuple2) => tuple1.IsEqual(tuple2);
    public static bool operator !=(RayTuple tuple1, RayTuple tuple2) => !tuple1.IsEqual(tuple2);

    public static RayTuple operator +(RayTuple tuple) => tuple;
    public static RayTuple operator +(RayTuple tuple1, RayTuple tuple2) => 
        new(tuple1.X + tuple2.X, tuple1.Y + tuple2.Y, tuple1.Z + tuple2.Z, tuple1.W + tuple2.W);

    public static RayTuple operator -(RayTuple tuple) =>
        new(-tuple.X, -tuple.Y, -tuple.Z, -tuple.W);
    public static RayTuple operator -(RayTuple tuple1, RayTuple tuple2) =>
        new(tuple1.X - tuple2.X, tuple1.Y - tuple2.Y, tuple1.Z - tuple2.Z, tuple1.W - tuple2.W);

    public static RayTuple operator *(RayTuple tuple, double multiplier) =>
        new(tuple.X * multiplier, tuple.Y * multiplier, tuple.Z * multiplier, tuple.W * multiplier);

    public static RayTuple operator /(RayTuple tuple, double divisor) =>
        new(tuple.X / divisor, tuple.Y / divisor, tuple.Z / divisor, tuple.W / divisor);
}