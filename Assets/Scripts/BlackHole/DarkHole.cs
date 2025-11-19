using System.Collections;
using UnityEngine;

public class DarkHole : MonoBehaviour
{
    public float atractionForce;
    public float rangeAtraction;
    public float timeToDisappear;

    private void OnEnable()
    {
        StartCoroutine(Disappear());
    }

    void Update()
    {
        ObjectDetect();
    }

    public void ObjectDetect()
    {
        Collider2D[] objs = Physics2D.OverlapCircleAll(transform.position, rangeAtraction);

        if(objs.Length != 0)
        {
            for(int i = 0; i < objs.Length; i++)
            {
                if(objs[i].TryGetComponent(out Rigidbody2D movement))
                {
                    Vector2 force = transform.position - movement.transform.position;
                    movement.AddForce(force * atractionForce * Time.deltaTime);
                }
            }
        }

    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(timeToDisappear);
        gameObject.SetActive(false);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeAtraction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.GetDamage(1);
            gameObject.SetActive(false);
        }
    }
}
