using UnityEngine;

public class SheepMovement : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float turnSpeed = 120.0f;
    public float minChangeTime = 1.0f;
    public float maxChangeTime = 3.0f;
    public Vector3 modelForward = Vector3.left;

    private Vector3 changeDirection = Vector3.right;
    private Vector3 moveDirection;
    private Rigidbody rb;

    private float nextChangeTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        moveDirection = transform.TransformDirection(modelForward).normalized;

        ScheduleNextRandomTurn();
    }


    void Update()
    {
        // Checks if it's time to change direction and randomly decides to turn left or right
        if (Time.time >= nextChangeTime)
        {
            changeDirection = (Random.value > 0.5f) ? Vector3.right : Vector3.left;
            ScheduleNextRandomTurn();
        }
    }

    void FixedUpdate()
    {
        // Rotates the sheep based on the changeDirection and turnSpeed, then moves it forward
        float turnStep = turnSpeed * Time.fixedDeltaTime * changeDirection.x;
        moveDirection = Quaternion.AngleAxis(turnStep, Vector3.up) * moveDirection;

        // Normalizes the moveDirection to ensure consistent speed and applies it to the Rigidbody's velocity
        Vector3 flatMove = moveDirection;
        flatMove.Normalize();
        rb.linearVelocity = flatMove * walkSpeed;

        //Turn the character so it faces where it’s moving.
        transform.rotation = Quaternion.FromToRotation(modelForward, flatMove);

    }


    private void OnCollisionEnter(Collision collision)
    {
        // If the sheep collides with a wall, it turns around by reversing the changeDirection and rotating 180 degrees
        if (collision.gameObject.CompareTag("Wall"))
        {
            changeDirection = -changeDirection;
            moveDirection = Quaternion.AngleAxis(180f, Vector3.up) * moveDirection;
        }
    }

    //makes so the sheep randomly turns left or right 
    private void ScheduleNextRandomTurn()
    {
        nextChangeTime = Time.time + Random.Range(minChangeTime, maxChangeTime);
    }
}
