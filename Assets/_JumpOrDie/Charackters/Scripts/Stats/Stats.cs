using UnityEngine;

namespace JumpOrDie
{
    public abstract class Stats : MonoBehaviour
    {
        [SerializeField] private int _currentValue;
        [SerializeField] private int _maximumValue;

        public int MaximumValue { get => _maximumValue; }
        public int CurrentValue
        { 
            get => _currentValue; 

            protected set
            {
                _currentValue = value;
                if (_currentValue > _maximumValue)
                {
                    _currentValue = _maximumValue;
                }
                else if (_currentValue < 0)
                {
                    _currentValue = 0;
                }
            }
        }

        public void Reduce(int damage)
        {
            _currentValue -= damage;
            if (_currentValue < 0)
            {
                _currentValue = 0;
            }
        }

        public void Increase(int recovery)
        {
            _currentValue += recovery;
            if (_currentValue > _maximumValue)
            {
                _currentValue = _maximumValue;
            }
        }

        protected virtual void OnValidate()
        {
            if (CurrentValue < 0)
            {
                CurrentValue = 0;
            }
            else if (CurrentValue > MaximumValue)
            {
                CurrentValue = MaximumValue;
            }
        }
    }
}
