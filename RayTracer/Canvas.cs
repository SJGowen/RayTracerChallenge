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

    public void SaveAsPPM(string filename)
    {
        using (StreamWriter header = new(filename))
        {
            header.WriteLine("P3");
            header.WriteLine($"{Width} {Height}");
            header.WriteLine("255");
        }
    }

    public static List<string> ReadFromPPM(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename)) throw new ArgumentNullException(nameof(filename));

        List<string> list = new();
        using (StreamReader reader = new(filename))
        {
            while (reader.Peek() >= 0)
            {
                string? line = reader.ReadLine();
                if (line != null) list.Add(line);
            }
        }

        return list;
    }
}