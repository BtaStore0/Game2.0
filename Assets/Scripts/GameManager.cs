using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    bool isGameOver = false;

    void Awake() { Instance = this; }

    void Update()
    {
        if (!isGameOver)
        {
            score = Mathf.FloorToInt(Time.timeSinceLevelLoad * 10);
        }

        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void OnPlayerHit()
    {
        if (isGameOver) return;
        isGameOver = true;
        Debug.Log("Game Over! Score: " + score);
        Time.timeScale = 0f;
    }
}
