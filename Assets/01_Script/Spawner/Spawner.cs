using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnSpeed;
    [SerializeField] List<GameObject> spawnList = new List<GameObject>();
    [SerializeField] bool canSpawn;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        canSpawn = true;
        while(canSpawn)
        {
            yield return new WaitForSeconds(spawnSpeed);
            spawnList.Add(Instantiate(enemyPrefab, transform));
        }
    }
}
