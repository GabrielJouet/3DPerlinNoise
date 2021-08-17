/// <summary>
/// Class that will handle high values points position.
/// </summary>
class Point
{
    /// <summary>
    /// X component.
    /// </summary>
    public int X { get; private set; }

    /// <summary>
    /// Y component.
    /// </summary>
    public int Y { get; private set; }

    /// <summary>
    /// Z component.
    /// </summary>
    public int Z { get; private set; }


    public Point(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}