using UnityEngine;
using UnityEngine.InputSystem;

public class HoseScript : MonoBehaviour
{
    bool switchSide = false;
    public GameObject water;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // put position into a new Vector2 so that its values may be changed
        Vector2 newPos = transform.position;

        // get mouse position
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        // code applies if the left hose is switched to
        if (switchSide == false && newPos.x < 0)
        {
            newPos.y = mousePos.y;
            if (Keyboard.current.anyKey.isPressed)
            {
                water.SetActive(true);
            }
            else
            {
                water.SetActive(false);
            }
        }

        // code applies if the right hose is switched to
        if (switchSide == true && newPos.x > 0)
        {
            newPos.y = mousePos.y;
            if (Keyboard.current.anyKey.isPressed)
            {
                water.SetActive(true);
            }
            else
            {
                water.SetActive(false);
            }
        }

        transform.position = newPos;
    }

    public void SwitchSide()
    {
        switchSide = !switchSide;
    }
}
