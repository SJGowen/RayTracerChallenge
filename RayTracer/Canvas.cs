namespace RayTracer;
public class Canvas
{
    public int Width { get; }
    public int Height { get; }

    public Colour[,] Pixels { get; set; }

    public Canvas(int width, int height)
    {
        Width = width;
        Height = height;

        Pixels = new Colour[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Pixels[i, j] = new Colour(0, 0, 0);
            }
        }
    }
}