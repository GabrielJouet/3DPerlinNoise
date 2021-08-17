using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Class that will handle 3D perlin noise generation.
/// </summary>
class PerlinNoiseGenerator
{
    /// <summary>
    /// Generation settings.
    /// </summary>
    private GenerationSettings _settings;

    /// <summary>
    /// Generation settings.
    /// </summary>
    private float[,,] _perlinNoise;

    /// <summary>
    /// File used for saving perlin.
    /// </summary>
    private string _filePath;

    /// <summary>
    /// Object used to handle random operations.
    /// </summary>
    private Random _rand;


    /// <summary>
    /// Method used to generate the perlin noise.
    /// </summary>
    /// <param name="newSettings">Settings used to generate the perlin noise</param>
    public void GeneratePerlinNoiseMatrix(GenerationSettings newSettings)
    {
        _settings = newSettings;
        _filePath = Directory.GetCurrentDirectory() + "/perlin.dat";

        if (_settings.Seed != 0)
            _rand = new Random(_settings.Seed);
        else
            _rand = new Random();

        _perlinNoise = new float[_settings.Width, _settings.Height, _settings.Length];
        List<Point> importancePoints = new List<Point>();

        //We compute the optimal number of start points.
        for (int i = 0; i < (int)Math.Floor((_settings.Width * _settings.Height * _settings.Length) / 4000 * _settings.PointLikeHood); i++)
        {
            int x = _rand.Next(0, _settings.Width);
            int y = _rand.Next(0, _settings.Height);
            int z = _rand.Next(0, _settings.Length);

            _perlinNoise[x, y, z] = _settings.MaxValue;
            importancePoints.Add(new Point(x, y, z));
        }

        //For each point we compute the distance between other start points and apply a falloff on them.
        float total;
        for (int x = 0; x < _settings.Width; x++)
        {
            for (int y = 0; y < _settings.Height; y++)
            {
                for (int z = 0; z < _settings.Length; z++)
                {
                    total = 0f;
                    foreach (Point importancePoint in importancePoints)
                    {
                        float result = (float)Math.Sqrt(Math.Pow(x - importancePoint.X, 2) + Math.Pow(y - importancePoint.Y, 2) + Math.Pow(z - importancePoint.Z, 2)) * _settings.FallOff;

                        //Equivalent of a clamp.
                        if (result > _settings.MaxValue)
                            result = _settings.MaxValue;
                        else if (result < 0f)
                            result = 0f;

                        total += 1 - result;
                    }

                    //Equivalent of a clamp.
                    if (total > _settings.MaxValue)
                        _perlinNoise[x, y, z] = _settings.MaxValue;
                    else if (total < 0f)
                        _perlinNoise[x, y, z] = 0f;
                    else
                        _perlinNoise[x, y, z] = total;
                }
            }

            //Display for debug.
            Console.WriteLine(x + " / " + _settings.Width);
        }

        SaveData();
    }


    /// <summary>
    /// Method used to save data in a file.
    /// </summary>
    private void SaveData()
    {
        try
        {
            StringBuilder newString = new StringBuilder();

            //Data will be saved with the following pattern:
            //width,height,length;x,y,z:value;x,y,z:value; and so on.
            newString.Append(_settings.Width + "," + _settings.Height + "," + _settings.Length + ";");

            for (int x = 0; x < _settings.Width; x++)
                for (int y = 0; y < _settings.Height; y++)
                    for (int z = 0; z < _settings.Length; z++)
                        newString.Append(x + "," + y + "," + z + ":" + _perlinNoise[x, y, z] + ";");

            File.WriteAllText(_filePath, newString.ToString());
            Console.WriteLine("Done");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}