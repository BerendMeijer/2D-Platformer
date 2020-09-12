using System.Collections;
using UnityEngine;

public static class Vector3Extensions
{
    public static Vector2 ToVector2(this Vector3 value)
    {
        return new Vector2(value.x, value.y);
    }
}
