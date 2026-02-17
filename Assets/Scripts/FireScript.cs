using UnityEngine;

public class FireScript : MonoBehaviour
{
    int whichSide;
    public GameObject buildingBody;
    public SpriteRenderer water;
    public GameObject firePrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buildingBody.GetComponent<GameObject>();
        
        Vector2 newPos = transform.position;

        // sets the object's x position to a random side of the building (left or right)
        whichSide = Random.Range(0, 2);
        if (whichSide == 0)
        {
            newPos.x = buildingBody.transform.position.x - buildingBody.transform.localScale.x / 2;
        }
        if (whichSide == 1)
        {
            newPos.x = buildingBody.transform.position.x + buildingBody.transform.localScale.x / 2;
        }

        // sets y position to something random within the height of the building
        newPos.y = Random.Range(buildingBody.transform.position.y - buildingBody.transform.localScale.y / 2, buildingBody.transform.position.y + buildingBody.transform.localScale.y / 2);

        transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        // runs if there is fire in the water
        if (water.bounds.Contains(transform.position)) {
            Instantiate(firePrefab);
            Destroy(gameObject);
        }
    }
}
