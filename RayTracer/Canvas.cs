namespace RayTracer;
public class Canvas
{
    public int Width { get; }
    public int Height { get; }
    public Colour[,] Pixels { get; }

    public Canvas(int width, int height)
    {
        Width = width;
        Height = height;

        Pixels = new Colour[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Pixels[x, y] = new Colour();
            }
        }
    }

    public Colour GetPixel(int pixelX, int pixelY)
    {
        if (pixelX < 0 || pixelX >= Width || pixelY < 0 || pixelY >= Height)
        {
            Console.WriteLine($"Tried to Get Pixel[{pixelX},{pixelY}] from a Grid({Width},{Height}).");
        }

        return Pixels[Math.Clamp(pixelX, 0, Width - 1), Math.Clamp(pixelY, 0, Height - 1)];
    }

    public void SetPixel(int pixelX, int pixelY, Colour colour)
    {
        if (pixelX < 0 || pixelX >= Width || pixelY < 0 || pixelY >= Height)
        {
            Console.WriteLine($"Tried to Set Pixel[{pixelX},{pixelY}] to Colour({colour.Red},{colour.Green},{colour.Blue}) in a Grid({Width},{Height}).");
        }

        Pixels[Math.Clamp(pixelX, 0, Width - 1), Math.Clamp(pixelY, 0, Height - 1)] = colour;
    }
}