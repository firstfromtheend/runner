using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instanceLC;

    private void Awake()
    {
        if (instanceLC != null) Destroy(gameObject);
        else instanceLC = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
