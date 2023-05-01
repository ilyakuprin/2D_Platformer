using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        int lastScene = 0;
        SceneManager.LoadScene(lastScene);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
