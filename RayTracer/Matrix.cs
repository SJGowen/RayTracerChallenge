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

    public static Matrix operator *(Matrix multiplicand, Matrix multiplier)
    {
        if (4 != multiplicand.Cells.GetLength(0) || 4 != multiplier.Cells.GetLength(0) ||
            4 != multiplicand.Cells.GetLength(1) || 4 != multiplier.Cells.GetLength(1))
        {
            throw new ArgumentException("You can only multiply 4x4 Matrixes");
        }

        Matrix result = new(4, 4);

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                result.Cells[x, y] = multiplicand.Cells[x, 0] * multiplier.Cells[0, y] +
                    multiplicand.Cells[x, 1] * multiplier.Cells[1, y] +
                    multiplicand.Cells[x, 2] * multiplier.Cells[2, y] +
                    multiplicand.Cells[x, 3] * multiplier.Cells[3, y];
            }
        }

        return result;
    }
}
