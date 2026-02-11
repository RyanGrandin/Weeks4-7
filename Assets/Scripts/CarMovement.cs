using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 3f;
    private float startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // moves the object
        Vector2 newPos = transform.position;
        newPos.x += speed * Time.deltaTime;
        transform.position = newPos;

        // sets the object back to its starting position if it exits the screen
        Vector2 screenPos = Camera.main.WorldToScreenPoint(newPos);
        if (screenPos.x < 0 || screenPos.x > Screen.width)
        {
            newPos.x = startPos;
        }

        transform.position = newPos;
    }
}
