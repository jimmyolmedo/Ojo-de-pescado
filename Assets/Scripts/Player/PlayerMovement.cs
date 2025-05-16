using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //variables
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    Vector2 move;
    bool canMove = true;

    //properties
    public bool CanMove {  get => canMove; set => canMove = value; }

    //methods
    private void FixedUpdate()
    {
        rb.linearVelocity = transform.up * move.y * speed * Time.deltaTime;

        rb.rotation -= move.x * speed * Time.deltaTime;
    }
    private void Update()
    {
        if (canMove == false)
        {
            move = Vector2.zero;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (GameManager.CurrentState != GameState.Gameplay) { return; }

        move = context.ReadValue<Vector2>();
    }


}
