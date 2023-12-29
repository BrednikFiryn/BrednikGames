using UnityEngine;

public class AnimMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private Movement movement;

    private void Start()
    {
        anim = GetComponent<Animator>();
        movement = FindObjectOfType<Movement>();
        CheckGround();
    }

    private void FixedUpdate()
    {
        AnimLogic();
    }

    /// <summary>
    /// Movement animation logic
    /// </summary>
    private void AnimLogic()
    {
        bool isMoving = movement.movementHorizontal != 0;
        bool isMovingBack = movement.speedBack != 0;

        anim.SetBool("Walk", isMoving);
        anim.SetBool("WalkBack", isMovingBack);

        if (!isMoving && !isMovingBack)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("WalkBack", false);
        }

        // Stop walking
        anim.SetBool("Walk", isMoving);
        anim.SetBool("WalkBack", isMovingBack);

        // Jump animation
        CheckGround();
    }

    /// <summary>
    /// Ground check
    /// </summary>
    private void CheckGround()
    {
        bool isGrounded = movement.isGrounded;

        if (!isGrounded)
        {
            GetComponent<AudioSource>().Pause();
            anim.SetBool("isJump", true);
            anim.SetBool("Walk", false);
            anim.SetBool("WalkBack", false);
        }
        else anim.SetBool("isJump", false);
    }
}
