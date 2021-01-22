using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static float healthAmount; //Creates a variable called healthAmount

    Rigidbody2D rb;

    public GameObject closeEnemyPrefab; //Sets the closeEnemyPrefab gameobject
    bool spawned = false; //Creates a boolean called spawned and sets it to false

    System.Random rng = new System.Random();
    int num; //Creates an int variable called num

    [SerializeField] BoxCollider2D bc;
    [SerializeField] Vector2 cubeSize; //Creates a vector2 called cubeSize 
    [SerializeField] Vector2 cubeCenter; //Creates a vector2 called cubeCenter


    private void Awake()
    {
        Transform cubeTrans = bc.GetComponent<Transform>(); //Sets the transform cubeTrans 
        cubeCenter = cubeTrans.position; //Sets the cubeCenter variable to the position of the transform


        cubeSize.x = cubeTrans.localScale.x * bc.size.x; // Multiply by scale because it does affect the size of the collider
        cubeSize.y = cubeTrans.localScale.y * bc.size.y; // Multiply by scale because it does affect the size of the collider
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        {
            if (other.tag == "Player") //Runs the if statement if the Player collides with the enemy spawn box
            {
                if (spawned == false) //Runs the if statement if the boolean varaible is false
                {
                    for (int i = 0; i < (num = rng.Next(2, 6)); i++) //Runs the for loop until i > the random number generated
                    {
                        GameObject e = Instantiate(closeEnemyPrefab, GetRandomPosition(), Quaternion.identity); //Instantiates the closeEnemyPrefab
                    }
                    Destroy(this.gameObject); //Destroys the enemy spawn box collider
                }
                spawned = true; //Sets the boolean variable to true
            }
        }
    }

    private Vector2 GetRandomPosition() //Creates the vector2 for the random position
    {
        Vector2 randomPosition = new Vector2(Random.Range(-cubeSize.x / 2, cubeSize.x / 2), Random.Range(-cubeSize.y / 2, cubeSize.y / 2)); //Sets random position vector2 to a random position in the cube

        return cubeCenter + randomPosition; //Returns the values cubeCenter and randomPosition
    }

}