using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D characterRigidBody = null;

    [SerializeField]
    [Range(1, 10)]
    private float jumpForce = 5.0f;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            characterRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
