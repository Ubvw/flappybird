using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    // Encapsulation: These fields are private and only accessible within this class.
    // [SerializeField] allows Unity to modify them in the Inspector without making them public.
    [SerializeField] private FlyBehavior player;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject titleScreen;

    private int score; // Encapsulation: Keeps score private so only this class can manage it.

    private void Awake()
    {
        Application.targetFrameRate = 60;
        ShowTitleScreen(); // Abstraction: Handles UI setup at the start.
        Pause(); // Abstraction: Pauses the game without modifying Time.timeScale directly here.
    }

    public void Play()
    {
        ResetGame(); // Abstraction: Resets game state in a separate method.
        StartGame(); // Abstraction: Starts the game with necessary setup.
    }

    public void Pause()
    {
        // Encapsulation: Controls how the game is paused, preventing direct changes to Time.timeScale.
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        // Encapsulation: Ensures score updates happen only through this method.
        score++;
        UpdateScoreText(); // Abstraction: Updates UI in a separate method.
    }

    public void GameOver()
    {
        // Encapsulation: Handles game-over logic in a single method.
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    private void ShowTitleScreen()
    {
        // Encapsulation: Manages the visibility of UI elements at the start.
        titleScreen.SetActive(true);
        scoreText.gameObject.SetActive(false);
        playButton.SetActive(true);
        gameOver.SetActive(false);
    }

    private void ResetGame()
    {
        // Encapsulation: Keeps score reset logic separate from other methods.
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // Encapsulation: Manages how the score text is updated in the UI.
        scoreText.text = score.ToString();
    }

    private void StartGame()
    {
        // Encapsulation: Ensures the game starts properly without modifying UI elements directly in Play().
        playButton.SetActive(false);
        gameOver.SetActive(false);
        titleScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        Time.timeScale = 1f;
        player.enabled = true;

        DestroyAllPipes(); // Abstraction: Clears previous pipes in a separate method.
    }

    private void DestroyAllPipes()
    {
        // Abstraction: Handles pipe cleanup instead of doing it inside StartGame().
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        foreach (var pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
    }
}
