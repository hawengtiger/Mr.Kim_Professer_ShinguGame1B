using UnityEngine;
using KinematicCharacterController;
using KinematicCharacterController.Examples;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public ExampleCharacterController character;

    bool wasGrounded;
    bool isJumping;

    void Update()
    {
        if (animator == null || character == null || character.Motor == null)
            return;

        bool isGrounded =
            character.Motor.GroundingStatus.IsStableOnGround;

        animator.SetBool("Grounded", isGrounded);

        Vector3 planarVelocity =
            Vector3.ProjectOnPlane(
                character.Motor.Velocity,
                character.Motor.CharacterUp);

        float speed = planarVelocity.magnitude;
        animator.SetFloat("Speed", speed);

        float verticalVelocity =
            Vector3.Dot(
                character.Motor.Velocity,
                character.Motor.CharacterUp);

        // Á¡ÇÁ ½ÃÀÛ
        if (wasGrounded &&
            !isGrounded &&
            verticalVelocity > 0.1f &&
            !isJumping)
        {
            animator.ResetTrigger("Jump");
            animator.SetTrigger("Jump");

            isJumping = true;
        }

        // ³«ÇÏ
        bool freeFall =
            !isGrounded &&
            verticalVelocity < -0.1f;

        animator.SetBool("FreeFall", freeFall);

        // ÂøÁö
        if (isGrounded)
        {
            isJumping = false;

            animator.ResetTrigger("Jump");
            animator.SetBool("FreeFall", false);
        }

        wasGrounded = isGrounded;
    }
}