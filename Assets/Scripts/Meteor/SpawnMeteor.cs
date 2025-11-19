using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    [SerializeField] Vector2 limitX;
    [SerializeField] float posY;
    [SerializeField] int meteorCount;
    [SerializeField] GameObject meteorPrefab;
    [SerializeField] List<GameObject> meteorList;

    void Start()
    {
        for(int i = 0; i < meteorCount; i++)
        {
           GameObject obj = Instantiate(meteorPrefab, gameObject.transform.position, Quaternion.identity);
           meteorList.Add(obj);
           obj.SetActive(false);
        }

        StartCoroutine(SpawnTime());
    }

    void Spawn()
    {
        for(int i = 0; i < meteorList.Count; i++)
        {
            if(meteorList[i].activeSelf == false)
            {
                meteorList[i].transform.position = this.transform.position;
                meteorList[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            float xPos = Random.Range(limitX.x, limitX.y);
            transform.position = new Vector3(xPos, posY);

            for(int i = 0; i < meteorCount; i++)
            {
                Spawn();
                yield return new WaitForSeconds(.5f);
            }
        }
    }
}
