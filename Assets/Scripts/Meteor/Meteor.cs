using System.Collections;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] Vector2 limitsX;
    [SerializeField] Vector2 limitsY;
    [SerializeField] float speed;
    [SerializeField] float activeTime;

    private void OnEnable()
    {
        SetDirection();
        StartCoroutine(Desactive());
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void SetDirection()
    {
        Vector3 direction = new Vector2(Random.Range(limitsX.x, limitsX.y), Random.Range(limitsY.x, limitsY.y));

        Vector3 velocity = direction - transform.position;
        velocity.Normalize();
        transform.up = velocity;
        
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
