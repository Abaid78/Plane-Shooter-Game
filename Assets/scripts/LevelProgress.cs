using UnityEngine;
using UnityEngine.SceneManagement;
[SerializeField]
public class LevelProgress : MonoBehaviour
{
    private float _totalDefeatedEnemies;  // Total number of enemies defeated
    public Spawner enemySpawner;           // Reference to the enemy spawner for obtaining the total number of enemies to spawn
    private float _currentLevelProgress;   // Current progress of the level
    private int _currentLevelIndex = 0;    // Index representing the current level; used for saving data across levels using PlayerPrefs

    // Property for totalDefeatedEnemies
    public float TotalDefeatedEnemies
    {
        get { return _totalDefeatedEnemies; }
        set { _totalDefeatedEnemies = value; }
    }

    // Property for currentLevelProgress
    public float CurrentLevelProgress
    {
        get { return _currentLevelProgress; }
        set { _currentLevelProgress = value; }
    }

    private void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _currentLevelIndex = currentSceneIndex;
    }

    // Function to calculate the level progress based on defeated enemies
    // Function run in EnemyScript
    public void CalculateLevelProgress()
    {
        // Calculate the current level progress as a percentage
        _currentLevelProgress = _totalDefeatedEnemies / enemySpawner.totalEnemyToSpawn * 100;

        if (_currentLevelProgress >= PlayerPrefs.GetInt("Level_" + _currentLevelIndex + "_Progress"))
        {
            PlayerPrefs.SetInt("Level_" + _currentLevelIndex + "_Progress", (int)_currentLevelProgress);
            // Save PlayerPrefs data immediately
            PlayerPrefs.Save();
        }
    }
}