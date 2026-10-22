using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;

    public Transform pointA, pointB;
    private Rigidbody2D rb;
    private Vector2 target, velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = pointB.position;
    }

    public Vector2 GetVelocity()
    {
        return velocity;
    }

    private void FixedUpdate()
    {
        Vector2 move = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        
        rb.MovePosition(move);

        if (Vector2.Distance(rb.position, target) < 0.1f)
        {
            target = (target == (Vector2)pointA.position) ? pointB.position : pointA.position;
        }

        velocity = (move - rb.position) / Time.fixedDeltaTime;
    }
}
