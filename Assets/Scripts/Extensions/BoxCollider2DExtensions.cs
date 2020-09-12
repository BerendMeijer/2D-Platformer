using UnityEngine;

public static class BoxCollider2DExtensions
{
    public static Vector2 GetWorldPosition(this BoxCollider2D boxCollider)
    {
        return boxCollider.transform.position.ToVector2() + boxCollider.offset;
    }
}
