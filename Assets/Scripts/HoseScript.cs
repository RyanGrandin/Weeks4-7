using UnityEngine;
using UnityEngine.InputSystem;

public class HoseScript : MonoBehaviour
{
    bool switchSide = false;
    public GameObject water;
    public SpriteRenderer waterSR;
    int whichSide;
    public GameObject buildingBody;
    public GameObject firePrefab;
    public GameObject fire;
    public GameObject firstFire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fire = firstFire;
        fire.transform.position = FirePosition();
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

            // spray water when a key is held down
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

            // spray water when a key is held down
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

        // runs if there is fire in the water
        if (waterSR.bounds.Contains(FirePosition()))
        {
            Debug.Log("Water contains fire. Fire Position = " + FirePosition());
            Destroy(fire);
            fire = Instantiate(firePrefab, FirePosition(), Quaternion.identity);
        }
    }

    // change the hose that the player controls
    public void SwitchSide()
    {
        switchSide = !switchSide;
    }

    Vector2 FirePosition()
    {
        Vector2 firePos = new Vector2();

        // sets the fire's x position to a random side of the building (left or right)
        whichSide = Random.Range(0, 2);
        if (whichSide == 0)
        {
            firePos.x = buildingBody.transform.position.x - buildingBody.transform.localScale.x / 2;
        }
        if (whichSide == 1)
        {
            firePos.x = buildingBody.transform.position.x + buildingBody.transform.localScale.x / 2;
        }

        // sets the fire's y position to something random within the height of the building
        firePos.y = Random.Range(buildingBody.transform.position.y - buildingBody.transform.localScale.y / 2, buildingBody.transform.position.y + buildingBody.transform.localScale.y / 2);

        return firePos;
    }
}
