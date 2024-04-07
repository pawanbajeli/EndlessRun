
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameScene");
    }


}
