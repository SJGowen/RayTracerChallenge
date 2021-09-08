namespace RayTracer;
public static class PPMFile
{
    public static void CanvasToPPM(Canvas canvas, string filename)
    {
        SaveAsPPMHeader(canvas, filename);
        SaveAsPPMBody(canvas, filename);
        SaveAsPPMFooter(filename);
    }

    public static void SaveAsPPMHeader(Canvas canvas, string filename, bool append = false)
    {
        using StreamWriter header = new(filename, append);
        header.WriteLine("P3");
        header.WriteLine($"{canvas.Width} {canvas.Height}");
        header.WriteLine("255");
    }

    public static void SaveAsPPMBody(Canvas canvas, string filename, bool append = true)
    {
        using StreamWriter body = new(filename, append);
        string line = "";
        for (int y = 0; y < canvas.Height; y++)
        {
            for (int x = 0; x < canvas.Width; x++)
            {
                if (line != "") line += " ";
                line += ToPPMString(canvas.Pixels[x, y]);

                if (line.Length > 70)
                {
                    int pos = 70;
                    while (!Char.IsWhiteSpace(line[pos])) pos--;
                    string newLine = line[(pos + 1)..];
                    body.WriteLine(line.Substring(0, pos));
                    line = newLine;
                }
            }

            body.WriteLine(line);
            line = "";
        }
    }

    public static string ToPPMString(Colour colour)
    {
        return $"{Normalise(colour.Red)} {Normalise(colour.Green)} {Normalise(colour.Blue)}";
    }

    private static string Normalise(double colour)
    {
        return $"{(int)Math.Round(Math.Clamp(colour * 255, 0, 255))}";
    }

    public static void SaveAsPPMFooter(string filename, bool append = true)
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
