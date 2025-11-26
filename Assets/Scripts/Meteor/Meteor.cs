using System.Collections;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] Vector2 limitsX;
    [SerializeField] Vector2 limitsY;
    [SerializeField] float speed;
    [SerializeField] float activeTime;
    [SerializeField] GameObject warning;
    bool canMove = true;

    private void OnEnable()
    {
        StartCoroutine(SetDirection());
        StartCoroutine(Desactive());
    }

    private void Update()
    {
        if(canMove == true)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }

    IEnumerator SetDirection()
    {
        canMove = false;
        Vector3 direction = new Vector2(Random.Range(limitsX.x, limitsX.y), Random.Range(limitsY.x, limitsY.y));
        Vector3 velocity = direction - transform.position;
        velocity.Normalize();
        transform.up = velocity;
        warning.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        warning.SetActive(false);
        canMove = true;
    }

    IEnumerator Desactive()
    {
        yield return new WaitForSeconds(activeTime);
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.GetDamage(player.CurrentHealth);
            gameObject.SetActive(false);
        }
    }
}
