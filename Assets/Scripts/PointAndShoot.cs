using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    [SerializeField]
    public GameObject gun; //Sets the gun gameobject
    private Vector3 target; //Creates a vector3 called target

    public Transform Player; //Sets the player to the transform target

    public GameObject bulletPrefab; //Sets the bullet prefab gameobject
    public float bulletSpeed = 60.0f; //Sets the bullet speed
    public GameObject bulletStart; //Sets the
    private AudioSource gunshot; //creates the audio file variable for the gunshot sound

    private void Start()
    {
        gunshot = GetComponent<AudioSource>(); //Gets the audio file from the assets folder
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        Vector3 difference = target - gun.transform.position; //Sets the vector to difference between the mouse point on the screen and gun position 
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Sets rotationZ tothe arc tangent of y and x of difference and converts to degrees
        gun.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ); //Sets rotation of gun to rotationZ|

        if (Input.GetMouseButtonDown(0)) //Calls the if function when Left Click is pressed
        {
            float distance = difference.magnitude; //Makes the variable distance have a magnitude of 1
            Vector2 direction = difference / distance; //Sets the vector direction to be vector difference divided by distance
            direction.Normalize(); //Makes the vector direction have a magnitude of 1
            fireBullet(direction, rotationZ); //Calls the fireBullet function passing in the direction and z axis rotation
        }

        if (Input.GetKeyDown(KeyCode.Escape))//Closes the game when the escape key is pressed
        {
            Application.Quit();//Closes the game
        }
    }

    void fireBullet(Vector2 direction, float rotationZ) //fireBullet function
    {
        GameObject b = Instantiate(bulletPrefab); //Instantiates the bullet from the bullet prefab
        b.transform.position = bulletStart.transform.position; //Sets the position of the instantiated object to the end of the gun on the player
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ); //Sets the roatation of the bullet to be the correct rotation for the direction the bullet is being fired
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed; //Sets the speed of the bullet in the given direction
        gunshot.Play(); //Plays the gunshot sound when the gun is fired.
    }
}
