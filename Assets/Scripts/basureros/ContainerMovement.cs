using UnityEngine;
using UnityEngine.InputSystem;

public class ContainerMovement : MonoBehaviour
{
    [SerializeField] int ID;
    float rad = 0;
    [SerializeField] float speed = 5;
    [SerializeField] float distance = 2;
    Vector2 move;

    private void Start()
    {
        //invertir a uno de los objetos, para que aparezcan en direcciones distintas
        if(ID == 0)
        {
            distance *= -1;
        }
    }

    private void Update()
    {
        Move();
    }

    //metodo para hacer que los basureros orbiten alrededor de la tierra
    void Move()
    {
        rad -= speed * Time.deltaTime;

        float sin = Mathf.Sin(rad) * distance;
        float cos = Mathf.Cos(rad) * distance;

        transform.localPosition = new Vector3(cos, sin, 0);
    }
}
