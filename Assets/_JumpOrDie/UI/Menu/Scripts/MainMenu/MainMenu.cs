using UnityEngine;
using UnityEngine.SceneManagement;

namespace JumpOrDie
{
    public class MainMenu : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.visible = true;
        }

        public void PlayButton()
        {
            LoadLevel(PlayerPrefs.GetInt(new StringNamePlayerPrefs().LastLevel));
        }

        public void LoadSelectedLevel(int level)
        {
            LoadLevel(level);
        }

        public void ExitButton()
        {
            Application.Quit();
        }

        private void LoadLevel(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}
