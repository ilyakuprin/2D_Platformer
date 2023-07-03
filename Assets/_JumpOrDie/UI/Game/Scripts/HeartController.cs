using UnityEngine;
using UnityEngine.UI;

namespace JumpOrDie
{
    public class HeartController : MonoBehaviour
    {
        private GameObject[] _hearth;
        private int _countHearth;
        private float _colorR;
        private float _colorG;
        private float _colorB;
        private float _colorA;
        private readonly float _disabledHeartcolorA = 0.25f;

        public int CountHearth { get => _countHearth; }

        private void Awake()
        {
            int numberHearth = 0;
            foreach (Transform _ in transform) 
            {
                numberHearth++;
            }
            _hearth = new GameObject[numberHearth];

            numberHearth = 0;
            foreach (Transform child in transform)
            {
                _hearth[numberHearth] = child.gameObject;
                numberHearth++;
            }
            _countHearth = _hearth.Length;

            var color = _hearth[0].GetComponent<Image>().color;
            _colorR = color.r;
            _colorG = color.g;
            _colorB = color.b;
            _colorA = color.a;
        }

        public void SubtractHeart()
        {
            _countHearth -= 1;

            if (_countHearth >= 0)
            {
                ChangeColorA(_disabledHeartcolorA);
            }
        }

        public void AddHeart()
        {
            if (_countHearth < _hearth.Length)
            {
                ChangeColorA(_colorA);
                _countHearth += 1;
            }
        }
        
        public void AddHeart(GameObject heartGameObject)
        {
            if (_countHearth < _hearth.Length)
            {
                ChangeColorA(_colorA);
                _countHearth += 1;

                heartGameObject.GetComponent<Renderer>().enabled = false;
                heartGameObject.GetComponent<Collider2D>().enabled = false;
            }
        }

        private void ChangeColorA(float colorA)
        {
            _hearth[_countHearth].GetComponent<Image>().color = new Color(_colorR, _colorG, _colorB, colorA);
        }
    }
}
