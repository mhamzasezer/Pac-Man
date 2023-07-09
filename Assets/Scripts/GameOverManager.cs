using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public float delayBeforeGameOver = 2f;
    public string gameOverSceneName = "GameOverScene";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Game over logic here, such as displaying the game over UI or performing other actions.

            // Invoke the LoadGameOverScene method after the specified delay
            Invoke("LoadGameOverScene", delayBeforeGameOver);
        }
    }

    private void LoadGameOverScene()
    {
        // Load the game over scene
        SceneManager.LoadScene(gameOverSceneName);
    }
}
