using UnityEngine;
using UnityEngine.Events;

public class ContactSensor : MonoBehaviour
{
    public SpriteRenderer hazard;
    public bool inHazard = false;
    public UnityEvent OnEnterSensor;
    public UnityEvent OnExitSensor;
    public UnityEvent<float> OnRandomNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hazard.bounds.Contains(transform.position))
        {
            if (inHazard == true)
            {
                // still in hazard
            }
            else
            {
                // entered hazard
                Debug.Log("Entered the sensor.");
                OnEnterSensor.Invoke();
                inHazard = true;
            }
        }
        else
        {
            if (inHazard)
            {
                // exited hazard
                Debug.Log("Exited the sensor.");
                OnExitSensor.Invoke();
                OnRandomNumber.Invoke(Random.Range(0, 10));
                inHazard = false;
            }
            else
            {
                // still outside of hazard
            }
        }
    }
    public void ShowNumber(float number)
    {
        Debug.Log(number);
    }
}
