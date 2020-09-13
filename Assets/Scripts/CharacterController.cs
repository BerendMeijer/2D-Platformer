using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D characterRigidBody = null;

    [SerializeField]
    private BoxCollider2D characterBoxCollider = null;

    [SerializeField]
    [Range(1, 10)]
    private float jumpForce = 5.0f;

    [SerializeField]
    [Range(0.0001f, 0.1f)]
    private float groundCheckDistance = 0.05f;

    [SerializeField]
    private float jumpCooldownTime = 0.5f;

    private float? activeJumpCooldownTime = 0.0f;

    private void Update()
    {
        if (Input.GetButton("Jump") && !IsJumpCooldownActive() && IsGrounded())
        {
            characterRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            activeJumpCooldownTime = jumpCooldownTime;
        }

        if (activeJumpCooldownTime.HasValue)
        {
            activeJumpCooldownTime = activeJumpCooldownTime.Value - Time.deltaTime;
            if (activeJumpCooldownTime < 0.0f)
            {
                activeJumpCooldownTime = null;
            }
        }
    }

    private bool IsJumpCooldownActive()
    {
        return activeJumpCooldownTime.HasValue;
    }

    public bool IsGrounded()
    {
        return Physics2DExtensions.BoxCast(characterBoxCollider.GetWorldPosition(),
                                           characterBoxCollider.size,
                                           0.0f, /*angle*/
                                           Vector2.down, /*direction*/
                                           groundCheckDistance);
    }
}
