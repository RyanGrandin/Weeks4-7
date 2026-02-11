using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class FrogMovement : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    float car1Distance;
    float car2Distance;
    float car3Distance;
    public TextMeshProUGUI endText;
    public GameObject endTextObject;
    public float victoryLine = 4; // remember to change this to be a position relative to the top of the screen

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            newPos.y += 1;
        }
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            newPos.y -= 1;
        }
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            newPos.x -= 1;
        }
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            newPos.x += 1;
        }
        transform.position = newPos;

        // gets distance of the frog from the cars
        car1Distance = Vector2.Distance(transform.position, car1.transform.position);
        car2Distance = Vector2.Distance(transform.position, car2.transform.position);
        car3Distance = Vector2.Distance(transform.position, car3.transform.position);

        // if the frog is hit by a car
        if (car1Distance < 1 || car2Distance < 1 || car3Distance < 1)
        {
            endText.text = "You Lose";
            endTextObject.SetActive(true);
            gameObject.SetActive(false);
        }

        // if the frog successfully crosses the road
        if (transform.position.y >= victoryLine)
        {
            endText.text = "You Win";
            endTextObject.SetActive(true);
        }
    }
}
