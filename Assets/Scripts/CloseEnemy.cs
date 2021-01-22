using UnityEngine;

public class CloseEnemy : MonoBehaviour
{
    public Transform player; //Sets the player to the transform target
    private Rigidbody2D rb; //Creates the rigidbody variable

    [SerializeField]
    float speed = 8.5f; //Sets the speed of the enemy


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //Sets the player transform to the gameobject with the tag Player
    }

    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); //Sets the rigidbody of the CloseEnemy
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //Gets the enemy to move towards the player
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet") //Runs the if statement if a bullet collides with an enemy
        {
            Destroy(other.gameObject); //Destroys the instance of the bullet
            Destroy(this.gameObject); //Destroys the instance of the enemy
        }
        if (other.tag == "Player") //Runs the if statement if the enemy collides with an player
        {
            Destroy(this.gameObject); //Destroys the instance of the enemy
        }
    }
}