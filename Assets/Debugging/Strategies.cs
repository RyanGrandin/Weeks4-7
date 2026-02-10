using UnityEngine;

public class Strategies : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        // loop ten times
        for (int i = 0; i < 10; i++)
        {
            // instantiate prefab at increasing x and y position. 0 in z. no rotation.
            float x = i;
            Debug.Log(i + "/" + 10 + " = " + i / 10f);
            float y = i/10f;
            Debug.Log("y = " + y);
            float z = 0;
            Instantiate(prefab, new Vector3 (x, y, z), Quaternion.identity);
        }
    }

}
