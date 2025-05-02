using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float rad = 0;
    [SerializeField] float speed = 5;
    [SerializeField] float distance = 2;
    Vector2 move;

    private void Update()
    {
        //rad -= speed * Time.deltaTime;
        if (move.x > 0) { rad -= speed * Time.deltaTime; }
        else if (move.x < 0) { rad += speed * Time.deltaTime; }

        float sin = Mathf.Sin(rad) * distance;
        float cos = Mathf.Cos(rad) * distance;

        transform.localPosition = new Vector3(cos, sin, 0);

        Vector3 tangent = new Vector3(-Mathf.Sin(rad), Mathf.Cos(rad), 0);

        transform.right = -tangent;
    }

    public void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        //if (_move.x > 0) { rad -= speed * Time.deltaTime; }
        //else if (_move.x < 0) { rad += speed * Time.deltaTime; }
    }
}
