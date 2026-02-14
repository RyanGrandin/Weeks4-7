using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Frog : MonoBehaviour
{
    public Transform tongue;
    public Transform face;
    public Transform destination;
    public float t;
    public bool timerRunning = false;
    public float speed = 1;

    public GameObject bugPrefab;
    public Bug spawnedBug;
    public bool needRespawn = false;

    public GameObject gameOverScreen;
    public GameTimer gameTimer;
    public TextMeshProUGUI scoreDisplay;
    public int score = 0;
    public bool gameTimerRunning = true;

    public AudioSource SFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RespawnBug();
        scoreDisplay.text = score.ToString();
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameTimerRunning) return;
        if (!timerRunning && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            timerRunning = true;
        }
        if (timerRunning)
        {
            t += speed * Time.deltaTime;
            if (t > 1)
            {
                speed = speed * -1;
            }
            if (t < 0)
            {
                speed = speed * -1;
                timerRunning = false;
                t = 0;
                if (needRespawn)
                {
                    RespawnBug();
                }
            }
            tongue.position = Vector2.Lerp(face.position, destination.position, t);
            if (needRespawn == false && spawnedBug.sr.bounds.Contains(tongue.position) == true)
            {
                SFX.Play();
                Destroy(spawnedBug.gameObject);
                needRespawn = true;
                score += 1;
                scoreDisplay.text = score.ToString();
            }
        }
        else
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            destination.position = mousePos;
        }
    }

    void RespawnBug()
    {
        GameObject bug = Instantiate(bugPrefab, Random.insideUnitCircle * 4, Quaternion.identity);
        spawnedBug = bug.GetComponent<Bug>();
        needRespawn = false;
    }

    public void RestartGame()
    {
        score = 0;
        t = 0;
        timerRunning = false;
        tongue.position = Vector2.Lerp(face.position, destination.position, t);
        if (needRespawn)
        {
            RespawnBug();
        }
        gameOverScreen.SetActive(false);
        gameTimerRunning = true;
        gameTimer.timerValue = gameTimer.timerVisuals.maxValue;

    }
}
