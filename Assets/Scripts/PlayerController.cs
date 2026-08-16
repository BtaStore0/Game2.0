using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float laneDistance = 3f; // distance between lanes
    public float laneSwitchSpeed = 8f;
    public float forwardSpeed = 8f;
    public float jumpForce = 7f;
    public float gravity = -20f;
    public float slideDuration = 1.0f;

    int currentLane = 1; // 0-left,1-center,2-right
    CharacterController controller;
    Vector3 velocity;
    bool isSliding = false;
    float slideTimer = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogWarning("PlayerController: No CharacterController found on the player object.");
        }
    }

    void Update()
    {
        // input (keyboard for desktop; replace with touch for mobile)
        if (Input.GetKeyDown(KeyCode.LeftArrow)) ChangeLane(-1);
        if (Input.GetKeyDown(KeyCode.RightArrow)) ChangeLane(1);
        if (Input.GetKeyDown(KeyCode.Space) && controller != null && controller.isGrounded) Jump();
        if (Input.GetKeyDown(KeyCode.LeftControl) && controller != null && controller.isGrounded) StartSlide();

        // lateral movement towards target lane
        float targetX = (currentLane - 1) * laneDistance;
        Vector3 targetPos = new Vector3(targetX, transform.position.y, transform.position.z);

        Vector3 move = Vector3.zero;
        float newX = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * laneSwitchSpeed);
        move.x = newX - transform.position.x;
        move.z = forwardSpeed;

        // gravity/jump
        if (controller != null)
        {
            if (controller.isGrounded)
            {
                if (velocity.y < 0) velocity.y = -1f;
            }
            velocity.y += gravity * Time.deltaTime;

            Vector3 finalMove = new Vector3(move.x, velocity.y, move.z) * Time.deltaTime;
            controller.Move(finalMove);
        }
        else
        {
            // fallback: simple transform movement if no CharacterController
            transform.Translate(new Vector3(move.x, 0, move.z) * Time.deltaTime);
        }

        // slide logic
        if (isSliding)
        {
            slideTimer -= Time.deltaTime;
            if (slideTimer <= 0) EndSlide();
        }
    }

    void ChangeLane(int dir)
    {
        currentLane = Mathf.Clamp(currentLane + dir, 0, 2);
    }

    void Jump()
    {
        velocity.y = jumpForce;
    }

    void StartSlide()
    {
        if (isSliding || controller == null) return;
        isSliding = true;
        slideTimer = slideDuration;
        // reduce controller height or play animation
        controller.height = controller.height * 0.5f;
    }

    void EndSlide()
    {
        if (!isSliding || controller == null) return;
        isSliding = false;
        controller.height = controller.height * 2f;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Obstacle"))
        {
            var gm = FindObjectOfType<GameManager>();
            if (gm != null) gm.OnPlayerHit();
        }
    }
}
