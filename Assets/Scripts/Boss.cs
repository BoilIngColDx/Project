using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject player; //Creates the player gameobject
    public GameObject boss; //Creates the boss gameobject

    public GameObject ghostProjectile; //Creates the ghostProjectile gameobject
    public GameObject projectileStart; //Creates the projectileStart gameobject
    public float ghostSpeed = 90.0f; //Creates and sets the ghostSpeed float variable

    float timer; //Creates a float variable called timer
    public static float waitingTime = 100000000f;//Creates a float variable called waitingTime

    public int bossHealth; //Creates the bossHealth variable

    void Update()
    {
        player = GameObject.FindWithTag("Player"); //Sets the player to the gameobject with the tag Player
        boss = GameObject.FindWithTag("Boss"); //Sets the boss to the gameobject with the tag Boss

        Vector3 difference = player.transform.position - boss.transform.position; //Sets the vector to difference between the player position and boss position 
        float rotationZ = Mathf.Atan2(difference.y, difference.x); //Sets rotationZ tothe arc tangent of y and x of difference

        timer += Time.deltaTime; //Adds the scince the last frame to the timer
        if (timer > waitingTime) //Calls the if function if the timer number is > 
        {
            float distance = difference.magnitude; //Makes the variable distance have a magnitude of 1
            Vector2 direction = difference / distance; //Sets the vector direction to be vector difference divided by distance
            direction.Normalize(); //Makes the vector direction have a magnitude of 1
            shootGhost(direction, rotationZ); //Calls the shootGhost function passing in the direction and z axis rotation
            timer = 0; //Resets the timer to 0
        }
    }

    void shootGhost(Vector2 direction, float rotationZ) //shootGhost function
    {
        GameObject w = Instantiate(ghostProjectile); //Instantiates the ghost from the ghost prefab
        w.transform.position = projectileStart.transform.position; //Sets the position of the instantiated object to the projectileStart on the boss
        w.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ); //Sets the roatation of the ghost to be the correct rotation for the direction the ghost is being fired
        w.GetComponent<Rigidbody2D>().velocity = direction * ghostSpeed; //Sets the speed of the ghost in the given direction
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet") //Runs the if statement if the boss collides with a bullet
        {
            if(bossHealth == 20) //Runs the if statement if the boss runs out of health
            {
                Destroy(this.gameObject); //Destroys the boss
                Application.Quit(); //Closes the game
            }
            else //Runs the else statement if the boss hasn't run out of health yet
            {
                Destroy(other.gameObject); //Destroys the instance of the bullet
                bossHealth++; //Removes a portion of health form the boss
            }
            
        }
    }
}