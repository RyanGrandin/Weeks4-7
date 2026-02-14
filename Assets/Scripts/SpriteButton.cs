using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteButton : MonoBehaviour
{
    SpriteRenderer sr;
    public Color defaultColour;
    public Color highlightedColour;
    public Color pressedColour;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (sr.bounds.Contains(mousePos))
        {
            sr.color = highlightedColour;
            MouseIsOver();
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                LeftButtonWasPressedThisFrame();
            }
            if (Mouse.current.leftButton.isPressed)
            {
                sr.color = pressedColour;
                LeftButtonIsPressed();
            }
            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                LeftButtonWasReleasedThisFrame();
            }
        }
        else
        {
            sr.color = defaultColour;
            MouseIsNotOver();
        }
    }

    void LeftButtonWasPressedThisFrame()
    {

    }

    void LeftButtonIsPressed()
    {

    }

    void LeftButtonWasReleasedThisFrame()
    {

    }

    void MouseIsOver()
    {

    }

    void MouseIsNotOver()
    {

    }
}
