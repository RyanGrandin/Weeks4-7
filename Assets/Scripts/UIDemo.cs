using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class UIDemo : MonoBehaviour
{
    private SpriteRenderer SR;
    public Image duckImage;
    public int clickCount = 0;
    public TextMeshProUGUI score;
    public Slider slider;
    public TextMeshProUGUI sliderDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        score.text = clickCount.ToString();

        slider.wholeNumbers = true;
        slider.value = 3;
    }

    // Update is called once per frame
    void Update()
    {
        sliderDisplay.text = slider.value.ToString();
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            ChangeColour();
        }
    }

    public void ChangeColour()
    {
        SR.color = Random.ColorHSV();
        duckImage.color = SR.color;
    }

    public void SetScaleBig(float scale)
    {
        transform.localScale = Vector3.one * scale;
    }

    public void countClicks()
    {
        clickCount++;
        score.text = clickCount.ToString();
    }
}
