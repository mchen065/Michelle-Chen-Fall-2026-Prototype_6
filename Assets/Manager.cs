using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public float timeLeft = 60f;

    public int keysCollected = 0;
    public int keysNeeded = 3;

    public TMP_Text timerText;
    public TMP_Text keyText;
    public TMP_Text loopText;

    public PlayerRewind playerRewind;

    public GameObject[] keys;

    public GameObject loseScreen;

    private bool loopStarted = false;
    private bool gameOver = false;

    void Start()
    {
        Time.timeScale = 1;

        loseScreen.SetActive(false);
        loopText.gameObject.SetActive(false);

        UpdateUI();
    }

    void Update()
    {
        if (gameOver)
            return;

        // Don't count time while  rewinding
        if (playerRewind.isRewinding == false)
        {
            timeLeft -= Time.deltaTime;
        }

        // First loop happens 30 seconds left
        if (timeLeft <= 30 && loopStarted == false)
        {
            StartTimeLoop();

            loopStarted = true;
        }

        // Time runs out
        if (timeLeft <= 0)
        {
            timeLeft = 0;

            LoseGame();
        }

        UpdateUI();
    }

    public void CollectKey()
    {
        keysCollected++;

        UpdateUI();
    }

    void StartTimeLoop()
    {
        loopText.gameObject.SetActive(true);

        loopText.text = "TIME LOOP!";

        // Start the rewind/loop
        playerRewind.StartRewind();

        // Reset the collected keys
        keysCollected = 0;

        // Bring all keys back
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].SetActive(true);
        }

        Invoke("HideLoopText", 2f);
    }

    void HideLoopText()
    {
        loopText.gameObject.SetActive(false);
    }

    void UpdateUI()
    {
        timerText.text =
            "Time: " + Mathf.CeilToInt(timeLeft);

        keyText.text =
            "Keys: " + keysCollected + "/" + keysNeeded;
    }

    public bool HasAllKeys()
    {
        return keysCollected >= keysNeeded;
    }

    public void WinGame()
    {
        gameOver = true;

        Time.timeScale = 0;
    }

    void LoseGame()
    {
        gameOver = true;

        loseScreen.SetActive(true);

        Time.timeScale = 0;
    }
}
