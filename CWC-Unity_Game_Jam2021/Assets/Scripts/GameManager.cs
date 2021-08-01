using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float restartDelay = 1f;
    bool gameHasEnded = false;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("restart", restartDelay);
        }

    }

    void restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
