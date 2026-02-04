using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SetAlienDescription : MonoBehaviour
{
    public TextMeshProUGUI description;
    public float distance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        distance = Vector2.Distance(transform.position, mousePos);
        if (distance <= 1)
        {
            description.text = "This is one of three alien sprites from the videogame Space Invaders";
        }
    }
}
