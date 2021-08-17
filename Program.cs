using System;

class Program
{
    private static void Main(string[] args)
    {
        GenerationSettings settings = new GenerationSettings();

        Console.WriteLine("Generation of a 3D Perlin Noise");
        Console.WriteLine("Seed of the generation, must be an integer, leave blank if not wanted: ");
        settings.Seed = int.Parse(Console.ReadLine());

        Console.WriteLine("World width, along x axis, must be an integer: ");
        settings.Width = int.Parse(Console.ReadLine());

        Console.WriteLine("World heigth, along y axis, must be an integer: ");
        settings.Height = int.Parse(Console.ReadLine());

        Console.WriteLine("World length, along z axis, must be an integer: ");
        settings.Length = int.Parse(Console.ReadLine());

        Console.WriteLine("Maximum value of a point, can be float: ");
        settings.MaxValue = float.Parse(Console.ReadLine());

        Console.WriteLine("Likehood of high value points apparition, can be float: ");
        settings.PointLikeHood = float.Parse(Console.ReadLine());

        Console.WriteLine("Fall off value per point, can be float: ");
        settings.FallOff = float.Parse(Console.ReadLine());

        PerlinNoiseGenerator perlin = new PerlinNoiseGenerator();
        perlin.GeneratePerlinNoiseMatrix(settings);

        Console.ReadLine();
    }
}