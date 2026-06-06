using UnityEngine;
using KinematicCharacterController;
using KinematicCharacterController.Examples;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public ExampleCharacterController character;

    bool wasGrounded;

    void Update()
    {
        if (animator == null || character == null || character.Motor == null)
            return;

        // 접지 상태
        bool isGrounded =
            character.Motor.GroundingStatus.IsStableOnGround;

        animator.SetBool("Grounded", isGrounded);

        // 이동 속도
        Vector3 planarVelocity =
            Vector3.ProjectOnPlane(
                character.Motor.Velocity,
                character.Motor.CharacterUp);

        float speed = planarVelocity.magnitude;

        animator.SetFloat("Speed", speed);

        // 수직 속도
        float verticalVelocity =
            Vector3.Dot(
                character.Motor.Velocity,
                character.Motor.CharacterUp);

        // 점프 시작
        if (wasGrounded &&
            !isGrounded &&
            verticalVelocity > 0.1f)
        {
            animator.SetBool("Jump", true);
        }

        // 낙하
        bool freeFall =
            !isGrounded &&
            verticalVelocity < -0.1f;

        animator.SetBool("FreeFall", freeFall);

        // 착지
        if (isGrounded)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("FreeFall", false);
        }

        wasGrounded = isGrounded;
    }
}