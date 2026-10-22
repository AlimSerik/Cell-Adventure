using UnityEngine;
using UnityEngine.InputSystem;

public class Cell : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private bool isGliding = false;
    private bool isTorn = false;
    private bool touch = false;

    private MovingPlatform currentPlatform;
    private Rigidbody2D rb;
    private InputAction moveAction, tornAction, glideAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Player/Move");
        tornAction = InputSystem.actions.FindAction("Player/Crouch");
        glideAction = InputSystem.actions.FindAction("Player/Jump");

        glideAction.performed += _ => ToggleGlider();
        tornAction.performed += _ => ToggleTorn();
    }

    private void ToggleGlider()
    {
        isGliding = !isGliding;
        if (isGliding)
        {
            isTorn = false;
            rb.gravityScale = 0.1f;
        } else
        {
            rb.gravityScale = 1f;
        }
    }

    private void ToggleTorn()
    {
        isTorn = !isTorn;
        if (isTorn && touch)
        {
            isGliding = false;
            rb.gravityScale = 0f;
            rb.linearVelocity = Vector2.zero;
        } else
        {
            rb.gravityScale = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        touch = true;
        if (collision.gameObject.TryGetComponent(out MovingPlatform platform))
        {
            currentPlatform = platform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touch = false;
        if (collision.gameObject.TryGetComponent(out MovingPlatform platform))
        {
            currentPlatform = null;
        }
    }

    private void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        float platfomSpeed = 0f;

        if (currentPlatform != null)
        {
            platfomSpeed = currentPlatform.GetVelocity().x;
        }

        if (!isTorn)
        {
            rb.linearVelocity = new Vector2(move.x * moveSpeed + platfomSpeed, rb.linearVelocity.y);
        }
    }
}
