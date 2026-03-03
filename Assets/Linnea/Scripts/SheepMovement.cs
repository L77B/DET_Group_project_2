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
        if (Time.time >= nextChangeTime)
        {
            changeDirection = (Random.value > 0.5f) ? Vector3.right : Vector3.left;
            ScheduleNextRandomTurn();
        }
    }

    void FixedUpdate()
    {
        float turnStep = turnSpeed * Time.fixedDeltaTime * changeDirection.x;
        moveDirection = Quaternion.AngleAxis(turnStep, Vector3.up) * moveDirection;

        Vector3 flatMove = moveDirection;
        flatMove.y = 0f;
        if (flatMove.sqrMagnitude > 0.0001f)
        {
            flatMove.Normalize();
            rb.linearVelocity = flatMove * walkSpeed;
            transform.rotation = Quaternion.FromToRotation(modelForward, flatMove);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            changeDirection = -changeDirection;
            moveDirection = Quaternion.AngleAxis(180f, Vector3.up) * moveDirection;
            Debug.Log("Collided with wall, flipping direction");
        }
    }

    private void ScheduleNextRandomTurn()
    {
        nextChangeTime = Time.time + Random.Range(minChangeTime, maxChangeTime);
    }
}
