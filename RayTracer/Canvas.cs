﻿namespace RayTracer;
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

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Pixels[x, y] = new Colour(0, 0, 0);
            }
        }
    }

    public void CanvasToPPM(string filename)
    {
        SaveAsPPMHeader(filename);
        SaveAsPPMBody(filename);
        SaveAsPPMFooter(filename);
    }

    public void SaveAsPPMHeader(string filename, bool append = false)
    {
        using StreamWriter header = new(filename, append);
        header.WriteLine("P3");
        header.WriteLine($"{Width} {Height}");
        header.WriteLine("255");
    }

    public void SaveAsPPMBody(string filename, bool append = true)
    {
        using StreamWriter body = new(filename, append);
        string line = "";
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (line != "") line += " ";
                line += Pixels[x, y].ToPPMString();

                if (line.Length > 70)
                {
                    int pos = 70;
                    while (!Char.IsWhiteSpace(line[pos])) pos--;
                    string newLine = line.Substring(pos + 1);
                    body.WriteLine(line.Substring(0, pos));
                    line = newLine;
                }
            }

            body.WriteLine(line);
            line = "";
        }
    }

    public void SaveAsPPMFooter(string filename, bool append = true)
    {
        using StreamWriter footer = new(filename, append);
        footer.WriteLine();
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