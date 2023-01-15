using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnEnemy()
    {
        int randomValue = Random.Range(0, enemy.Length);
        int randomXpos = Random.Range(-2, 2);
        Instantiate(enemy[randomValue], new Vector2(randomXpos, transform.position.y), Quaternion.identity);
    }
    IEnumerator EnemySpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            SpawnEnemy();
        }
    }
}
