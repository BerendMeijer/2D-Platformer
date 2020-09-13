using UnityEngine;

public class CharacterAnimatorParameterUpdater : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody = null;

    [SerializeField]
    private CharacterController characterController = null;

    [SerializeField]
    private Animator animator = null;

    [SerializeField]
    [Tooltip("This value is used to determine at what absolute vertical velocity the jump progress range starts and ends. This is used to rotate the character sprite, based on vertical velocity.")]
    private float maxAbsoluteVerticalVelocityForJumpProgress = 2.0f;

    private void Update()
    {
        animator.SetFloat("Horizontal velocity", rigidBody.velocity.x);
        animator.SetFloat("Vertical velocity", rigidBody.velocity.y);
        animator.SetBool("IsGrounded", characterController.IsGrounded());
        animator.SetFloat("Jump Progress", GetNormalizedJumpProgress());
    }

    /// <returns>The normalized progress of the jump; 0.0f -> going up, 0.5f -> at peak, 1.0f -> going down.</returns>
    private float GetNormalizedJumpProgress()
    {
        return 1.0f - rigidBody.velocity.y.MapRangeClamped(new Range(-maxAbsoluteVerticalVelocityForJumpProgress, maxAbsoluteVerticalVelocityForJumpProgress), new Range(0.0f, 1.0f));
    }
}
