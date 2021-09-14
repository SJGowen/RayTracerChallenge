namespace RayTracer;
public class Matrix
{
    public double[,] Cells { get; }

    public Matrix(int x, int y)
    {
        Cells = new double[x, y];
    }

    public void Add(params double[] values)
    {
        for (int x = 0; x < Cells.GetLength(0); x++)
            for (int y = 0; y < Cells.GetLength(1); y++)
                Cells[x, y] = values[x * Cells.GetLength(0) + y];
    }

    private bool IsEqual(Matrix matrix)
    {
        bool result = true;
        for (int x = 0; x < Cells.GetLength(0); x++)
            for (int y = 0; y < Cells.GetLength(1); y++)
                result = result && Equality.Equal(Cells[x, y], matrix.Cells[x, y]);

        return result;
    }

    public override bool Equals(Object? obj) => obj is Matrix matrix && IsEqual(matrix);

    public override int GetHashCode() => Cells.GetHashCode();

    public static bool operator ==(Matrix matrix1, Matrix matrix2) => matrix1.IsEqual(matrix2);

    public static bool operator !=(Matrix matrix1, Matrix matrix2) => !matrix1.IsEqual(matrix2);

}

