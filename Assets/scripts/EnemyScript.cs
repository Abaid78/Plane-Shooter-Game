using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameObject gunPoint1;
    public GameObject gunPoint2;
    public GameObject enemyBullet;
    public GameObject enemyFlash;
    public GameObject damageVFXPrefab;
    public GameObject enemyExplosionPrefab;
    public Healthbar healthbar;
    float health = 10f;
    float barSize = 1f;
    float damage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyShooting());
        enemyFlash.SetActive(false);
        damage = barSize / health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }
    // Damage Enemy and Decrease healthbar scale
    void HealthBarDamage()
    {
        if (health > 0)
        {
            health -= 1;
            barSize = barSize - damage;
            healthbar.SetBarSize(barSize);

        }
    }
    void EnemyFire()
    {
        Instantiate(enemyBullet, gunPoint1.transform.position, Quaternion.identity);
        Instantiate(enemyBullet, gunPoint2.transform.position, Quaternion.identity);
    }
    IEnumerator EnemyShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            EnemyFire();
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

            HealthBarDamage();
            Destroy(other.gameObject);
            GameObject damageVFX=Instantiate(damageVFXPrefab,other.transform.position,Quaternion.identity);
            Destroy(damageVFX,0.06f);
            if (health <= 0)
            {
                Destroy(gameObject);
                GameObject enemyExplosion = Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(enemyExplosion, 0.25f);
            }

        }
    }
}
