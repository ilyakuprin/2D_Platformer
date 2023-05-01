using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer2D
{
    public class DeathCanvas : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
