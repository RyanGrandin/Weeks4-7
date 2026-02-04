using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public SpriteRenderer player;
    public int health = 100;
    public AudioSource audioSource;
    public AudioClip attackSFX;
    public AudioClip deathSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse position
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        // is it inside sprite? And is button clicked?
        if (player.bounds.Contains(mousePos) == true && Mouse.current.leftButton.wasPressedThisFrame == true)
        {
            // yes: -1 health
            health -= 10;
            if (health <= 0)
            {
                audioSource.clip = deathSFX;
                audioSource.Play();
                gameObject.SetActive(false);
            }
            else
            {
                audioSource.clip = attackSFX;
                audioSource.Play();
            }
        }

        // update health bar with new health value
        healthBar.value = health;
    }

    public void Heal()
    {
        gameObject.SetActive(true);
        health = (int)healthBar.maxValue;
        healthBar.value = health;
    }
}
