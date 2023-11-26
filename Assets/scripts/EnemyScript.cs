using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Transform[] gunPoints;
    public GameObject enemyBullet;
    public GameObject enemyFlash;
    public GameObject damageVFXPrefab;
    public GameObject enemyExplosionPrefab;

    public GameObject coinPrefab;
    public Healthbar healthbar;
    private LevelProgress levelProgress;
    public AudioClip bulletSound;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioSource audioSource;
    public float shootTime = 1f;
    private float health = 10f;
    private float barSize = 1f;
    private float damage;
    private bool isDefeated = false;

    // Start is called before the first frame update
    private void Start()
    {
        levelProgress = GameObject.Find("LevelProgress").GetComponent<LevelProgress>();
        StartCoroutine(EnemyShooting());
        enemyFlash.SetActive(false);
        damage = barSize / health;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    // Damage Enemy and Decrease healthbar scale
    private void HealthBarDamage()
    {
        if (health > 0)
        {
            health -= 1;
            barSize = barSize - damage;
            healthbar.SetBarSize(barSize);
        }
    }

    private void EnemyFire()
    {
        for (int i = 0; i < gunPoints.Length; i++)
            Instantiate(enemyBullet, gunPoints[i].transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        if (isDefeated)
        {
            levelProgress.totalDefeatedEnemies++;
            levelProgress.CalculateLevelProgress();
        }
    }

    private IEnumerator EnemyShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootTime);
            EnemyFire();
            //audioSource.PlayOneShot(bulletSound, 0.4f);
            enemyFlash.SetActive(true);
            yield return new WaitForSeconds(0.07f);
            enemyFlash.SetActive(false);
        }
    }

    //Detacting Colliders
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            //audioSource.PlayOneShot(damageSound);
            HealthBarDamage();
            Destroy(other.gameObject);
            GameObject damageVFX = Instantiate(damageVFXPrefab, other.transform.position, Quaternion.identity);
            Destroy(damageVFX, 0.06f);
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                isDefeated = true;
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
                GameObject enemyExplosion = Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(enemyExplosion, 0.25f);

                Destroy(gameObject);
            }
        }
    }
}