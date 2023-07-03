using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace JumpOrDie
{
    public class ChangeAudioSlider : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private string _volumePatrametr;
        private readonly int _minValueDb = -80;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            if (!PlayerPrefs.HasKey(_volumePatrametr))
            {
                PlayerPrefs.SetFloat(_volumePatrametr, 1);
            }
            _slider.value = PlayerPrefs.GetFloat(_volumePatrametr);
        }

        public void ChangeSlider()
        {
            PlayerPrefs.SetFloat(_volumePatrametr, _slider.value);
            _audioMixer.SetFloat(_volumePatrametr, (1 - _slider.value) * _minValueDb);
        }
    }
}
