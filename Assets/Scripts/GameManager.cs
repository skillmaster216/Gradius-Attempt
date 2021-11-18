using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Hud items
    [SerializeField]
    private TextMeshProUGUI livesText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject gameOverMenu;
    [SerializeField] private GameObject titleScreen;


    // Variables
    private bool _isGameOver = false;
    public bool isGameOver { get { return _isGameOver; } }
    private int currentLives = 3;
    private long currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }


    //[ Methods ]
    //[ Update Score ]
    public void UpdateScore(int points)
    {
        currentScore += points;
        scoreText.text = $"Score: {currentScore.ToString("D6")}";
        //Score: 0000##, leading zeros 6 number cap.
    }

    //[ Update Lives ]
    private void LoadLives()
    {
        livesText.text = $"Lives: {currentLives.ToString("D2")}";
        //Lives: 0#
    }

    public void UpdateLives( int live)
    {
        currentLives += live;
        if (currentLives < 0)
            GameOver();
        LoadLives();
    }

    //[ Game Over ]
    public void GameOver()
    {
        _isGameOver = true;
        GameObject.Find("Spawn Manager").GetComponent<EnemySpawner>().StopSpawning();
        gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        LoadLives();
        Time.timeScale = 1.0f;
    }
}
