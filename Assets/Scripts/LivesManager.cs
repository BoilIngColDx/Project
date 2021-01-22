using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{   
    private int lifeCounter; //Creates a lifeCounter variable

    private Text theText; //Creates the text variable
    // Start is called before the first frame update
    void Start()
    {
        theText = GetComponent<Text>(); //Sets the text variable to the text field from the engine

        lifeCounter = PlayerMovement.lives; //Sets the lifeCounter variable to the lives variable from the PlayerMovement class
    }

    // Update is called once per frame
    void Update()
    {
        theText.text = lifeCounter.ToString(); //Sets the text field to the variable lifeCounter as a string
    }

    public void TakeLife() 
    {
        lifeCounter--; //Removes one from the lifeCounter variable
    }
}
