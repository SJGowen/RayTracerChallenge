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
}

