using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Alien : MonoBehaviour
{
    //variables
    [SerializeField] bool isRoting = true;
    float rad = 0;
    [SerializeField] float speed = 5;
    [SerializeField] float distance = 12;
    bool InArea;

    //methods
    private void Start()
    {
        StartCoroutine(Attack());
    }

    private void Update()
    {
        Move();
    }

    //moverse alrededor de la camara en circulos
    void Move()
    {
        if (isRoting)
        {
            rad -= speed * Time.deltaTime;

            float sin = Mathf.Sin(rad) * distance;
            float cos = Mathf.Cos(rad) * distance;

            transform.localPosition = new Vector3(cos, sin, 0);
        }
    }

    //cambiar el movimiento para lanzar la basura
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(5f);

        //dejar de rotar
        isRoting = false;

        Vector2 oldPosition = transform.position;

        while (InArea == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, Planet.instance.transform.position, 3f * Time.deltaTime);
            yield return null;
        }

        //lanzar basura

        //volver a la distancia anterior
        Vector2 initialPos = transform.position;
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            transform.position = Vector2.Lerp(initialPos, oldPosition, i/1f);
            yield return null;
        }
        InArea = false;
        isRoting = true;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DetectAlien"))
        {
            InArea = true;
        }
    }
}
