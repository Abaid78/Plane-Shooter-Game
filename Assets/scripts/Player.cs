using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public GameObject playerExplosion;
    public PlayerHealth playerHealth;
    public GameObject damageVFXPrefab;
    public UIManager uiManager;
    public CoinCounter coinCounter;
    public AudioSource audioSource;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioClip coinSound;
    public float speed = 10f;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    // Start is called before the first frame update
    private void Start()
    {
        playerHealth = GameObject.Find("PlayerHealth").GetComponent<PlayerHealth>();
        coinCounter = GameObject.Find("CoinCounter").GetComponent<CoinCounter>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        //FindReferences();
        FindBoundries();
    }

    // Update is called once per frame
    private void Update()
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
        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 newPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                transform.position = Vector2.Lerp(transform.position, newPos, 10 * Time.deltaTime);
            }
        }

        // Use touch input for Android and iOS builds
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch (you may need to modify this based on your requirements)

            if (touch.phase == TouchPhase.Moved)
            {
                    Vector2 newPos = Camera.main.ScreenToWorldPoint(touch.position);
                    transform.position = Vector2.Lerp(transform.position, newPos, 10 * Time.deltaTime);
               
            }
        }

    }

    private void FindBoundries()
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
            audioSource.PlayOneShot(damageSound, 0.4f);
            GameObject damageVFX = Instantiate(damageVFXPrefab, other.transform.position, Quaternion.identity);
            Destroy(damageVFX, 0.06f);
            Destroy(other.gameObject);
            playerHealth.PlayerDamage();
            if (playerHealth.currentHealth <= 0)
            {
               
                GameObject blast = Instantiate(playerExplosion, transform.position, Quaternion.identity);
                Destroy(blast, 2f);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.4f);
                uiManager.ShowOnGameOver();
            }
        }
        if (other.gameObject.tag == "Coin")
        {
            coinCounter.AddCoins();
            Destroy(other.gameObject);
            audioSource.PlayOneShot(coinSound, 0.5f);
        }
    }

    private void FindReferences()
    {
        // Find objects by tag
        GameObject playerHealthObj = GameObject.FindGameObjectWithTag("PlayerHealth");
        GameObject coinCounterObj = GameObject.FindGameObjectWithTag("CoinCounter");
        GameObject uiManagerObj = GameObject.FindGameObjectWithTag("UIManager");

        // Check if objects were found
        if (playerHealthObj != null)
        {
            playerHealth = playerHealthObj.GetComponent<PlayerHealth>();
        }
        else
        {
            Debug.LogError("PlayerHealth object not found in the scene!");
        }

        if (coinCounterObj != null)
        {
            coinCounter = coinCounterObj.GetComponent<CoinCounter>();
        }
        else
        {
            Debug.LogError("CoinCounter object not found in the scene!");
        }

        if (uiManagerObj != null)
        {
            uiManager = uiManagerObj.GetComponent<UIManager>();
        }
        else
        {
            Debug.LogError("UIManager object not found in the scene!");
        }
    }
}