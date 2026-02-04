using UnityEngine;

public class Toggle : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMethod()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);

        //if (gameObject.activeInHierarchy)
        //{
        //    gameObject.SetActive(false);
        //}
        //else if (gameObject.activeInHierarchy == false)
        //{
        //    gameObject.SetActive(true);
        //}
    }
}
