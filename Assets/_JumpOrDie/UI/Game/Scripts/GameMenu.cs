using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JumpOrDie
{
    public class GameMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;
        private PlayerInput _playerInput;

        private AudioSource[] _audioSources;
        private List<AudioSource> _isPlayingAudioSource = new List<AudioSource>();

        private readonly int _buildIndexMenu = 0;

        private void Awake()
        {
            _audioSources = FindObjectsOfType<AudioSource>();
            Cursor.visible = false;

            _playerInput = FindObjectOfType<PlayerInput>();
        }

        private void Update()
        {
            if (Input.GetButtonDown(ConstantsInput.CANCEL))
            {
                if (_menu.activeInHierarchy)
                {
                    OnContinue();
                }
                else
                {
                    Cursor.visible = true;
                    Time.timeScale = 0;
                    _playerInput.enabled = false;

                    foreach (AudioSource source in _audioSources)
                    {
                        if (source != null)
                        {
                            if (source.isPlaying)
                            {
                                _isPlayingAudioSource.Add(source);
                                source.Pause();
                            }
                        }
                    }

                    _menu.SetActive(true);
                }
            }
        }

        public void OnContinue()
        {
            Cursor.visible = false;
            Time.timeScale = 1;
            _playerInput.enabled = true;

            foreach (AudioSource source in _isPlayingAudioSource)
            {
                source.Play();
            }
            _isPlayingAudioSource = new List<AudioSource>();

            _menu.SetActive(false);
        }

        public void OnRepeat()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void OnMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(_buildIndexMenu);
        }
    }
}
