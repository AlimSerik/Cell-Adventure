using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatform : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed = 2f;
    private Rigidbody2D rb;
    private Vector2 target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = pointB.position;
    }

    private void FixedUpdate()
    {
        Vector2 move = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(move);

        if (Vector2.Distance(rb.position, target) < 0.1f)
        {
            target = (target == (Vector2)pointA.position) ? pointB.position : pointA.position;
        }
    }
}
