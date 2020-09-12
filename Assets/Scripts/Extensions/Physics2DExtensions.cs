using UnityEngine;

public static class Physics2DExtensions
{
    /// <summary>
    /// Casts a box against colliders in the scene, returning whether a collider was hit or not.
    /// </summary>
    public static bool BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance)
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(origin, size, angle, direction, distance);

        // A 'collider' property of null indicates that no collider was hit in the boxcast.
        if (raycastHit.collider == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
