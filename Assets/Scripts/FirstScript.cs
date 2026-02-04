using UnityEngine;

public class FirstScript : MonoBehaviour
{

    public float speed = 0.01f;

    Vector2 bottomLeft;
    Vector2 topRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //speed = Random.Range(0.01f, 0.3f);
        //transform.position = (Vector2)transform.position + Random.insideUnitCircle * 2;

        bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the object
        Vector2 newPos = transform.position;
        newPos.x += speed * Time.deltaTime;

        // Bounces the object off of the side of the screen
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0)
        {
            newPos.x = bottomLeft.x;
            speed *= -1;
        }
        if (screenPos.x > Screen.width)
        {
            newPos.x = topRight.x;
            speed *= -1;
        }
        transform.position = newPos;
    }
}
