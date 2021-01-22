using UnityEngine;

public class BossUpDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //Runs the if statement if a bullet collides with an enemy
        {
            Boss.waitingTime = 0.75f; //Sets the waitingTime variable in the boss class
            Destroy(this.gameObject); //Destroys the box collider
        }
    }
}
