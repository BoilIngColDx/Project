using UnityEngine;

public class Door : MonoBehaviour
{
    public float cameraXValue; //Create a float
    public float cameraYValue; //Create a float
    public float playerXValue; //Create a float
    public float playerYValue; //Create a float

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //Runs the if statement if the Player collides with a door
        {
            GameObject.Find("Main Camera").transform.position = new Vector3(cameraXValue, cameraYValue, -2); //Moves the player to a given point
            GameObject.Find("Player").transform.position = new Vector3(playerXValue, playerYValue, -1); //Moves the camera to a given point

        }
    }
}
