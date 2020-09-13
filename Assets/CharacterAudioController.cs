using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudioController : MonoBehaviour
{
    [SerializeField]
    private CharacterMovementController movementController = null;

    [SerializeField]
    private AudioSource jumpSound = null;

    private void OnEnable()
    {
        movementController.OnJump += PlayJumpSound;
    }

    private void OnDisable()
    {
        movementController.OnJump -= PlayJumpSound;
    }

    private void PlayJumpSound()
    {
        jumpSound.Play();
    }
}
