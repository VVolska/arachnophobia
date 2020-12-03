using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   
    public GameObject spawnGameObject;
    public Transform[] spawnPoints;
    public int enemyCount;
    public int id=0;
    public static int nextID = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    IEnumerator EnemyDrop()
    {
        while (enemyCount < 6)
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            spawnGameObject.tag = "enemy";
            nextID++;
            Instantiate(spawnGameObject, randomPoint.position, randomPoint.rotation);
            yield return new WaitForSeconds(10f);
            enemyCount += 1;
        }
    }
}
