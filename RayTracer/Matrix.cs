using System;

namespace RayTracer;
public class Matrix
{
    public double[,] Cells { get; }

    public Matrix(int x, int y)
    {
        Cells = new double[x, y];
    }

    public Matrix(params double[] values)
    {
        if (Cells is null)
        {
            if (values.Length != (int)Math.Sqrt(values.Length) * (int)Math.Sqrt(values.Length))
            {
                throw new ArgumentException("The number of arguments passed, has to be a perfect square (if not create the Matrix passing x and y, and then add the values to it).");
            }

            Cells = new double[(int)Math.Sqrt(values.Length), (int)Math.Sqrt(values.Length)];
        }

        Add(values);
    }

    public void Add(params double[] values)
    {
        for (int x = 0; x < Cells.GetLength(0); x++)
            for (int y = 0; y < Cells.GetLength(1); y++)
                Cells[x, y] = values[x * Cells.GetLength(1) + y];
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
            throw new ArgumentException("You can only multiply 4x4 Matrices");
        }

        Matrix result = new(4, 4);

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                result.Cells[x, y] = 
                    multiplicand.Cells[x, 0] * multiplier.Cells[0, y] +
                    multiplicand.Cells[x, 1] * multiplier.Cells[1, y] +
                    multiplicand.Cells[x, 2] * multiplier.Cells[2, y] +
                    multiplicand.Cells[x, 3] * multiplier.Cells[3, y];
            }
        }

        return result;
    }

    public static RayTuple operator *(Matrix matrix, RayTuple tuple)
    {
        if (4 != matrix.Cells.GetLength(0) || 4 != matrix.Cells.GetLength(1))
        {
            throw new ArgumentException("You can only multiply a 4x4 Matrix by a Tuple");
        }

        Matrix result = new(4, 1);

        for (int x = 0; x < 4; x++)
        {
            result.Cells[x, 0] =
                matrix.Cells[x, 0] * tuple.X +
                matrix.Cells[x, 1] * tuple.Y +
                matrix.Cells[x, 2] * tuple.Z +
                matrix.Cells[x, 3] * tuple.W;
        }

        return new(result.Cells[0, 0], result.Cells[1, 0], result.Cells[2, 0], result.Cells[3, 0]);
    }

    public static RayTuple operator *(RayTuple tuple, Matrix matrix)
    {
        return matrix * tuple;
    }

    public static Matrix Transpose(Matrix matrix)
    {
        double[] temp = new double[matrix.Cells.GetLength(0) * matrix.Cells.GetLength(1)];
        for (int x = 0; x < matrix.Cells.GetLength(0); x++)
        {
            for (int y = 0; y < matrix.Cells.GetLength(1); y++)
            {
                temp.SetValue(matrix.Cells[x, y], x + y * matrix.Cells.GetLength(0));
            }
        }

        Matrix result = new(matrix.Cells.GetLength(1), matrix.Cells.GetLength(0));
        result.Add(temp);
        return result;
    }
}
