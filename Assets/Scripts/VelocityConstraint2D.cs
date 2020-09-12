using UnityEngine;

public class VelocityConstraint2D : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody = null;

    [SerializeField]
    public Vector2 velocityLimit = Vector2.one;

    private void FixedUpdate()
    {
        rigidBody.velocity = rigidBody.velocity.Clamp(-velocityLimit, velocityLimit);
    }

    private void Reset()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
    }
}
