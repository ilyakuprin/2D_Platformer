using UnityEngine;
using UnityEngine.UI;

namespace JumpOrDie
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform _levels;

        private readonly string _lastlevel = new StringNamePlayerPrefs().LastLevel;
        private readonly int _numberInitiallyOpenLevels = 1;

        private void Awake()
        {
            if (!PlayerPrefs.HasKey(_lastlevel))
            {
                PlayerPrefs.SetInt(_lastlevel, _numberInitiallyOpenLevels);
            }

            for (int i = 0; i < PlayerPrefs.GetInt(_lastlevel); i++)
            {
                _levels.GetChild(i).GetComponent<Button>().interactable = true;
            }
        }
    }
}
