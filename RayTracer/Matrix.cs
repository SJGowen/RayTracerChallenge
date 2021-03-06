using System;
using System.Collections.Generic;

namespace RayTracer;
public class Matrix
{
    public double[,] Cells { get; }

    public int Rows { get => Cells.GetLength(0); }

    public int Columns { get => Cells.GetLength(1); }

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

    public static Matrix Identity = new(
        1, 0, 0, 0,
        0, 1, 0, 0,
        0, 0, 1, 0,
        0, 0, 0, 1);

    public static Matrix Translation(double x, double y, double z)
    {
        return new Matrix(
            1, 0, 0, x,
            0, 1, 0, y,
            0, 0, 1, z,
            0, 0, 0, 1);
    }

    public static Matrix Scaling(double x, double y, double z)
    {
        return new Matrix(
            x, 0, 0, 0,
            0, y, 0, 0,
            0, 0, z, 0,
            0, 0, 0, 1);
    }

    public static Matrix Shearing(double xy, double xz, double yx, double yz, double zx, double zy)
    {
        return new Matrix(
            1, xy, xz, 0,
            yx, 1, yz, 0,
            zx, zy, 1, 0,
            0, 0, 0, 1);
    }

    public void Add(params double[] values)
    {
        for (int x = 0; x < Rows; x++)
        {
            for (int y = 0; y < Columns; y++)
            {
                Cells[x, y] = values[x * Columns + y];
            }
        }
    }

    private bool IsEqual(Matrix matrix)
    {
        bool result = true;
        for (int x = 0; x < Rows; x++)
        {
            for (int y = 0; y < Columns; y++)
            {
                result = result && Equality.Equal(Cells[x, y], matrix.Cells[x, y]);
            }
        }

        return result;
    }

    public override bool Equals(Object? obj) => obj is Matrix matrix && IsEqual(matrix);

    public override int GetHashCode() => Cells.GetHashCode();

    public static Matrix RotationX(double radians)
    {
        return new Matrix(
            1, 0, 0, 0,
            0, Math.Cos(radians), -Math.Sin(radians), 0,
            0, Math.Sin(radians), Math.Cos(radians), 0,
            0, 0, 0, 1);
    }

    public static Matrix RotationY(double radians)
    {
        return new Matrix(
            Math.Cos(radians), 0, Math.Sin(radians), 0,
            0, 1, 0, 0,
            -Math.Sin(radians), 0, Math.Cos(radians), 0,
            0, 0, 0, 1);
    }

    public static Matrix RotationZ(double radians)
    {
        return new Matrix(
            Math.Cos(radians), -Math.Sin(radians), 0, 0,
            Math.Sin(radians), Math.Cos(radians), 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1);
    }

    public static bool operator ==(Matrix matrix1, Matrix matrix2) => matrix1.IsEqual(matrix2);

    public static bool operator !=(Matrix matrix1, Matrix matrix2) => !matrix1.IsEqual(matrix2);

    public static Matrix operator *(Matrix multiplicand, Matrix multiplier)
    {
        if (4 != multiplicand.Rows || 4 != multiplier.Rows ||
            4 != multiplicand.Columns || 4 != multiplier.Columns)
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
        if (4 != matrix.Rows || 4 != matrix.Columns)
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
        if (matrix.Rows != matrix.Columns)
        {
            throw new ArgumentException("You can only call Transpose on a Square Matrix");
        }

        double[] cellValues = new double[matrix.Rows * matrix.Columns];
        for (int x = 0; x < matrix.Rows; x++)
        {
            for (int y = 0; y < matrix.Columns; y++)
            {
                cellValues.SetValue(matrix.Cells[x, y], x + y * matrix.Rows);
            }
        }

        return new Matrix(cellValues);
    }

    public static double Determinant(Matrix matrix)
    {
        var sideLength = matrix.Rows;
        if (sideLength != matrix.Columns)
        {
            throw new ArgumentException("You can only call Determinant on a Square Matrix");
        }

        var result = 0.0;
        if (sideLength == 2)
        {
            result = matrix.Cells[0, 0] * matrix.Cells[1, 1] - matrix.Cells[0, 1] * matrix.Cells[1, 0];
        }
        else
        {
            for (int column = 0; column < sideLength; column++)
            {
                result += matrix.Cells[0, column] * Matrix.Cofactor(matrix, 0, column);
            }
        }

        return result;
    }

    public static Matrix SubMatrix(Matrix matrix, int row, int col)
    {
        if (row >= matrix.Rows)
        {
            throw new ArgumentException("Value of argument row is greater than the number of rows in the Matrix");
        }

        if (col >= matrix.Columns)
        {
            throw new ArgumentException("Value of argument col is greater than the number of columns in the Matrix");
        }

        var cellCount = 0;
        double[] cellValues = new double[(matrix.Rows - 1) * (matrix.Columns - 1)];
        for (int x = 0; x < matrix.Rows; x++)
        {
            for (int y = 0; y < matrix.Columns; y++)
            {
                if (x == row || y == col)
                {
                    continue;
                }

                cellValues.SetValue(matrix.Cells[x, y], cellCount);
                cellCount++;
            }
        }

        return new Matrix(cellValues);
    }

    public static double Minor(Matrix matrix, int row, int col)
    {
        var subMatrix = SubMatrix(matrix, row, col);
        return Determinant(subMatrix);
    }

    public static double Cofactor(Matrix matrix, int row, int col)
    {
        var cofactor = Minor(matrix, row, col);
        return (row + col) % 2 == 1 ? -cofactor : cofactor;
    }

    public static Matrix Inverse(Matrix matrix)
    {
        Matrix cofactorMatrix = new(matrix.Rows, matrix.Columns);
        for (int x = 0; x < matrix.Rows; x++)
        {
            for (int y = 0; y < matrix.Columns; y++)
            {
                cofactorMatrix.Cells[x, y] = Cofactor(matrix, x, y);
            }
        }

        var transposedMatrix = Transpose(cofactorMatrix);

        var determinant = Determinant(matrix);
        Matrix inverseMatrix = new(matrix.Rows, matrix.Columns);
        for (int x = 0; x < transposedMatrix.Rows; x++)
        {
            for (int y = 0; y < transposedMatrix.Columns; y++)
            {
                inverseMatrix.Cells[x, y] = transposedMatrix.Cells[x, y] / determinant;
            }
        }

        return inverseMatrix;
    }
}
