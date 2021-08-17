/// <summary>
/// This class handles generation settings for the perlin noise generator class.
/// </summary>
class GenerationSettings
{
    /// <summary>
    /// Seed used to change randomness.
    /// </summary>
    public int Seed { get; set; }

    /// <summary>
    /// Width of the perlin noise.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Height of the perlin noise.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Length of the perlin noise.
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    /// Maximum value allowed.
    /// </summary>
    public float MaxValue { get; set; }

    /// <summary>
    /// How much points with high values will be placed.
    /// </summary>
    public float PointLikeHood { get; set; }

    /// <summary>
    /// How much the signal dissipates.
    /// </summary>
    public float FallOff { get; set; }
}