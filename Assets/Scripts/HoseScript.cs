using UnityEngine;
using UnityEngine.InputSystem;

public class HoseScript : MonoBehaviour
{
    bool switchSide = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // put position into a new Vector2 so that its values may be changed
        Vector2 newPos = transform.position;

        // code applies if the left hose is switched to
        if (switchSide == false && newPos.x < 0)
        {
            // get mouse position
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            newPos.y = mousePos.y;
        }

        // code applies if the right hose is switched to
        if (switchSide == true && newPos.x > 0)
        {
            // get mouse position
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            newPos.y = mousePos.y;
        }

        transform.position = newPos;
    }

    public void SwitchSide()
    {
        switchSide = !switchSide;
    }
}
