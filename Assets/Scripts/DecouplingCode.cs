using System.Collections.Generic;
using UnityEngine;

public class DecouplingCode : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> sprites;
    public float speed = 0;
    public float direction = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRotation = transform.eulerAngles;
        newRotation.z += speed * direction * Time.deltaTime;
        transform.eulerAngles = newRotation;
    }

    public void ChangeColour()
    {
        sr.color = Random.ColorHSV();
    }

    public void ChangeSprite()
    {
        sr.sprite = sprites[Random.Range(0, sprites.Count)];
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void ChangeYPosition()
    {
        Vector2 newPos = transform.position;
        newPos.y = Random.Range(-4, 4);
        transform.position = newPos;
    }

    public void ChangeSpeed()
    {
        speed = Random.Range(10, 200);
    }

    public void ChangeDirection()
    {
        direction = direction * -1;
    }
}
