using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //variables
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    Vector2 move;
    [SerializeField] bool canMove = true;

    //methods
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(move.x, move.y) * speed * Time.deltaTime;
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
