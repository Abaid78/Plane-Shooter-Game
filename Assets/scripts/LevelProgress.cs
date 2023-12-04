using UnityEngine;
using UnityEngine.SceneManagement;
[SerializeField]
public class LevelProgress : MonoBehaviour
{
    public float totalDefeatedEnemies;  // Total number of enemies defeated
    public Spawner enemySpawner;         // Reference to the enemy spawner for obtaining the total number of enemies to spawn
    public float currentLevelProgress;   // Current progress of the level
    public int currentLevelIndex = 0;    // Index representing the current level; used for saving data across levels using PlayerPrefs

    private void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentLevelIndex != currentSceneIndex)
        {
            Debug.LogError("Set the currentLevelIndex according to the Scene Index: "+this.name);
            
        }
    }
    // Function to calculate the level progress based on defeated enemies
    //Function run in EnemyScript
    public void CalculateLevelProgress()
    {
        // Calculate the current level progress as a percentage
        currentLevelProgress = totalDefeatedEnemies / enemySpawner.totalEnemyToSpawn * 100;

        if (currentLevelProgress >= PlayerPrefs.GetInt("Level_" + currentLevelIndex + "_Progress"))
        {
            PlayerPrefs.SetInt("Level_" + currentLevelIndex + "_Progress", (int)currentLevelProgress);
            // Save PlayerPrefs data immediately
            PlayerPrefs.Save();
        }
    }
}