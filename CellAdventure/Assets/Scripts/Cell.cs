using UnityEngine;
using UnityEngine.InputSystem;

public class Cell : MonoBehaviour
{
    private Rigidbody2D rb;
    private InputAction moveAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Player/Move");
    }

    private void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(move.x, rb.linearVelocity.y);
    }
}
