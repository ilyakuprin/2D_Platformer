using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageAnimation : MonoBehaviour
{

    [SerializeField] private Sprite[] _sprites;
    [SerializeField, Range(0.1f, 10)] private float _timeAnimation = 2;
    [SerializeField] private bool _loop = true;

    private int _index = 0;
    private Image _image;
    private float _stopwatch = 0;
    private Coroutine _playAnimation;

    private void Awake()
    {
        if (_sprites != null)
        {
            _image = GetComponent<Image>();
        }
    }

    private IEnumerator PlayAnimation()
    {
        int spritesLength = _sprites.Length;
        float speed = _timeAnimation / spritesLength;

        while (_loop || _index != spritesLength)
        {
            _image.sprite = _sprites[_index % spritesLength];

            while (_stopwatch < speed)
            {
                _stopwatch += Time.deltaTime;
                yield return null;
            }

            _stopwatch = 0;
            _index++;

            yield return null;
        }
    }

    private void OnEnable()
    {
        _playAnimation = StartCoroutine(PlayAnimation());
    }

    private void OnDisable()
    {
        StopCoroutine(_playAnimation);
    }
}
