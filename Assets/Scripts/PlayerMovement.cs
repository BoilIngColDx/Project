using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public static int lives = 3; //Sets the variables lives to 3

    [SerializeField]
    public float speed; //Creates the speed float variable

    private LivesManager livesSystem; //Adds the class LivesManager to the PlayerMovement class

    private void Start()
    {
        livesSystem = FindObjectOfType<LivesManager>(); //Sets the LivesManager to the livesSystem variable
    }

    // Update is called once per frame
    void Update()
    {
        float _horizontalInput = Input.GetAxis("Horizontal"); //Sets the float _horizontalInput to the input from the horizontal axis
        transform.Translate(new Vector3(_horizontalInput, 0, 0) * speed * Time.deltaTime);

        float _verticalInput = Input.GetAxis("Vertical"); //Sets the float _verticalInput to the input from the vertical axis
        transform.Translate(new Vector3(0, _verticalInput, 0) * speed * Time.deltaTime);

        if(lives <= 0) //Runs the if statemnet if the variable lives reaches 0
        {
            Application.Quit(); //Closes the game
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CloseEnemy" || other.tag == "GhostProjectile") //Runs the if statement if the Player collides with an enemy or the boss projectile
        {
            livesSystem.TakeLife(); //Runs the TakeLife function from the LivesManager class
            lives--; //Removes one from the lives variable
        }
    }
}
