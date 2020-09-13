using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public delegate void OnJumpDelegate();
    public OnJumpDelegate OnJump;

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
    [Tooltip("In seconds.")]
    private float jumpCooldownTime = 0.5f;

    private CountDownTimer jumpCooldownTimer = new CountDownTimer(() => Time.timeSinceLevelLoad);

    private void Update()
    {
        if (Input.GetButton("Jump") && !IsJumpCooldownActive() && IsGrounded())
        {
            characterRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCooldownTimer.StartTimer(jumpCooldownTime);
            OnJump?.Invoke();
        }
    }

    private bool IsJumpCooldownActive()
    {
        return jumpCooldownTimer.IsRunning();
    }

    /// <summary>
    /// Checks whether there is a collider underneath the character with maximum distance of 'groundCheckDistance'.
    /// </summary>
    public bool IsGrounded()
    {
        return Physics2DExtensions.BoxCast(characterBoxCollider.GetWorldPosition(),
                                           characterBoxCollider.size,
                                           0.0f, /*angle*/
                                           Vector2.down, /*direction*/
                                           groundCheckDistance);
    }
}
