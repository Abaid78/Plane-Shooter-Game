using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float totalEnemyToSpawn = 10;
  
    public UIManager uiManager;
    private bool lastEnemySpawned = false;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(EnemySpawner());
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (lastEnemySpawned && FindObjectOfType<EnemyScript>() == null)
        {
            StartCoroutine(uiManager.ShowOnLevelComplete());
        }
    }

    public void SpawnEnemy()
    {
        int randomValue = Random.Range(0, enemy.Length);
        int randomXpos = Random.Range(-2, 2);
        Instantiate(enemy[randomValue], new Vector2(randomXpos, transform.position.y), Quaternion.identity);
    }

    private IEnumerator EnemySpawner()
    {
        for (int j = 0; j < totalEnemyToSpawn; j++)
        {
            yield return new WaitForSeconds(3);
            SpawnEnemy();
        }


        lastEnemySpawned = true;
    }
}