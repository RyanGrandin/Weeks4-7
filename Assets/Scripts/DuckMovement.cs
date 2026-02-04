using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class DuckMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // was button pressed this frame?
        if (Mouse.current.leftButton.wasPressedThisFrame == true && EventSystem.current.IsPointerOverGameObject() == false)
        {
            // yes: set object position to mouse position
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            transform.position = mousePos;
        }
    }
}
