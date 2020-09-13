using UnityEngine;

public static class FloatExtensions
{
    public static float MapRange(this float value, Range from, Range to)
    {
        // Percentage of value between min and max.
        float interpolant = Mathf.InverseLerp(from.Min, from.Max, value);
        return Mathf.Lerp(to.Min, to.Max, interpolant);
    }

    // First clamps the value to the 'from' range, and then remaps it.
    public static float MapRangeClamped(this float value, Range from, Range to)
    {
        return MapRange(Mathf.Clamp(value, from.Min, from.Max), from, to);
    }
}
