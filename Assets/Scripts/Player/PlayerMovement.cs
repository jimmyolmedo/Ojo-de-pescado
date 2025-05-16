using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //variables
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    Vector2 move;
    bool canMove = true;

    [Header("Visual")]
    [SerializeField] private GameObject derProp;
    [SerializeField] private GameObject izqProp;
    [SerializeField] private GameObject atrProp;
    [SerializeField] private GameObject adeProp;

    //properties
    public bool CanMove { get => canMove; set => canMove = value; }

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
        // if (move.y > 0) atrProp.SetActive(true);
        // else atrProp.SetActive(false);
        bool isFront;
        atrProp.SetActive(isFront = (move.y > 0) ? true : false);

        bool isBack;
        adeProp.SetActive(isBack = (move.y < 0) ? true : false);

        bool isDer;
        derProp.SetActive(isDer = (move.x > 0) ? true : false);

        bool isIzq;
        izqProp.SetActive(isIzq = (move.x < 0) ? true : false);
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (GameManager.CurrentState != GameState.Gameplay) { return; }

        move = context.ReadValue<Vector2>();
    }


}
