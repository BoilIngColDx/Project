using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) //Detects a collision between two box colliders
    {
        if (other.tag == "Wall") //Runs the if statement if a projectile collides with a wall
        {
            Destroy(this.gameObject); //Destroys the projectile when it hits a wall.
        }
    }
}
