using System.Collections;
using UnityEngine;

public class SpawnerDarkHole : MonoBehaviour
{
    [SerializeField] Vector2 limitsX;//limites en la posicion x del spawn
    [SerializeField] Vector2 limitsy;//limites en la posicion y del spawn

    [SerializeField] GameObject prefab;//prefab del agugero negro

    [SerializeField] CircleCollider2D planet;//planta tierra

    [SerializeField] float TimeToSpawn;

    private void Start()
    {
        StartCoroutine(spawnDarkHole());
    }

    IEnumerator spawnDarkHole()
    {
        while (true)
        {
            Vector2 position = new Vector2(Random.Range(limitsX.x, limitsX.y), Random.Range(limitsy.x, limitsy.y));

            float distance = Vector2.Distance(position, planet.transform.position);
            if (distance > planet.radius)
            {
                yield return new WaitForSeconds(TimeToSpawn);
                spawn(position);
            }
            else
            {
                yield return null;
            }
        }
    }

    void spawn(Vector2 _position)
    {
        prefab.transform.position = _position;
        prefab.gameObject.SetActive(true);
    }
}
