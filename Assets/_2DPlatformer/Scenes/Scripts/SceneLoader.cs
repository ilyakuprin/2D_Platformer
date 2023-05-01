using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer2D
{
    [RequireComponent(typeof(Collider2D))]
    public class SceneLoader : MonoBehaviour
    {
        private int _numberLastScene;
        private readonly HashLayers _hashLayers = new HashLayers();

        private void Awake()
        {
            _numberLastScene = SceneManager.sceneCountInBuildSettings - 1;
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            StartCoroutine(CheckAndLoad(collision));
        }

        private IEnumerator CheckAndLoad(Collider2D collision)
        {
            if (collision.gameObject.layer == _hashLayers.Player)
            {
                var numberActiveScene = SceneManager.GetActiveScene().buildIndex;

                if (_numberLastScene == numberActiveScene)
                {
                    SetPrefs(numberActiveScene);

                    StartCoroutine(new MoveToNextLevel().ReduceAndLoad(collision.gameObject, 0));
                }
                else
                {
                    var nextSceneNumber = numberActiveScene + 1;

                    SetPrefs(nextSceneNumber);

                    StartCoroutine(new MoveToNextLevel().ReduceAndLoad(collision.gameObject, nextSceneNumber));
                }
            }

            yield return null;
        }

        private void SetPrefs(int sceneNumber)
        {
            var prefs = new StringNamePlayerPrefs().LastLevel;

            if (!PlayerPrefs.HasKey(prefs))
            {
                PlayerPrefs.SetInt(prefs, sceneNumber);
            }
            else if (PlayerPrefs.GetInt(prefs) < sceneNumber)
            {
                PlayerPrefs.SetInt(prefs, sceneNumber);
            }
        }
    }
}
