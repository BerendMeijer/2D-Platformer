using UnityEngine;

public class CharacterAnimatorParameterUpdater : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody = null;

    [SerializeField]
    private Animator animator = null;

    private void Update()
    {
        animator.SetFloat("Horizontal velocity", rigidBody.velocity.x);
        animator.SetFloat("Vertical velocity", rigidBody.velocity.y);
    }
}
