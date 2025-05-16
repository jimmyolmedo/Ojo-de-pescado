using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] float minTimeAttack = 4;
    [SerializeField] float maxTimeAttack = 7;

    [SerializeField] List<Transform> attackPositions = new List<Transform>();
    [SerializeField] List<GameObject> attackPrefabs = new List<GameObject>();
    [SerializeField] int minAttackCount = 2;

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

            Vector3 tangent = new Vector3(-Mathf.Sin(rad), Mathf.Cos(rad), 0); // tangente a la trayectoria

            // Apuntar hacia adelante (por ejemplo, que el frente del sprite sea "right")
            transform.right = -tangent;
        }
    }

    //cambiar el movimiento para lanzar la basura
    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeAttack, maxTimeAttack));

            if (GameManager.CurrentState == GameState.Gameplay)
            {    
                //dejar de rotar
                isRoting = false;

                Vector2 oldPosition = transform.position;

                while (InArea == false)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Planet.instance.transform.position, 3f * Time.deltaTime);
                    yield return null;
                }

                //lanzar basura
                InstanceAttack();
                yield return new WaitForSeconds(1.5f);

                //volver a la distancia anterior
                Vector2 initialPos = transform.position;
                for (float i = 0; i < 1f; i += Time.deltaTime)
                {
                    transform.position = Vector2.Lerp(initialPos, oldPosition, i / 1f);
                    yield return null;
                }
                InArea = false;
                isRoting = true;
            }
        }  
    }

    public void InstanceAttack()
    {
        int count = Random.Range(minAttackCount, attackPositions.Count);
        List<Transform> pos = new List<Transform>();
        pos.AddRange(attackPositions);
        List<GameObject> objects = new List<GameObject>();
        objects.AddRange(attackPrefabs);

        for (int i = 0; i < count; i++)
        {
            int indexP = Random.Range(0, pos.Count);
            int indexO = Random.Range(0, objects.Count);

            Instantiate(objects[indexO], pos[indexP].position, Quaternion.identity);
            objects.RemoveAt(indexO);
            pos.RemoveAt(indexP);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DetectAlien"))
        {
            InArea = true;
        }
    }
}
