using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerExplosion;
    public PlayerHealthBar playerHealthBar;
    public GameObject damageVFXPrefab;
    public CoinCounter coinCounter;
    public float speed = 10f;
    float minX;
    float maxX;
    float minY;
    float maxY;
    float health = 20f;
    float damage = 0;
    float barFillAmount = 1f;
    // Start is called before the first frame update
    void Start()
    {
        damage = barFillAmount / health;
        FindBoundries();
    }

    // Update is called once per frame
    void Update()
    {
        // ///Player Movement using Input Manager
        // //Horizontal Movement(Left Right)
        // float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        // float newXpos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        // transform.position = new Vector2(newXpos, transform.position.y);
        // //Vertical Movement(UP and Down)
        // float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        // float newYpos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
        // transform.position = new Vector2(newXpos, newYpos);

        if(Input.GetMouseButton(0)){
            Vector2 newPos=Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
            transform.position=Vector2.Lerp(transform.position,newPos,10*Time.deltaTime);
        }
    }
    void FindBoundries()
    {
        Camera gameCamera = Camera.main;
        //convert position Viewport to WorldPoint
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + 0.8f;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - 0.8f;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + 0.7f;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - 0.7f;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            GameObject damageVFX=Instantiate(damageVFXPrefab,other.transform.position,Quaternion.identity);
            Destroy(damageVFX,0.06f);
            Destroy(other.gameObject);
            PlayerDamage();
            if (health <= 0)
            {
                GameObject blast = Instantiate(playerExplosion, transform.position, Quaternion.identity);
                Destroy(blast, 2f);
                Destroy(gameObject);
            }

        }
        if(other.gameObject.tag=="Coin"){
            Destroy(other.gameObject);
            coinCounter.AddCoins();
        }
    }
    // Damage the Player and Decrease the barFillAmount of the bar
    void PlayerDamage()
    {
        if (health > 0)
        {
            health = health - 1;
            barFillAmount = barFillAmount - damage;
            playerHealthBar.SetBarFillAmount(barFillAmount);

        }
    }
}
