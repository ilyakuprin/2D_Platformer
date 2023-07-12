using UnityEngine;

namespace JumpOrDie
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _currentValue;
        [SerializeField] private int _maximumValue;

        private readonly int _minimumHealth = 1;

        public int CurrentValue { get => _currentValue; }
        public int MaximumValue { get => _maximumValue; }

        private void Start()
        {
            if (_currentValue < _maximumValue && _currentValue > 0)
            {
                GetComponent<HealthChange>().ChangeHealBar();
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

        public bool Dead()
        {
            if (CurrentValue <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OnValidate()
        {
            if (_currentValue < _minimumHealth)
            {
                _currentValue = _minimumHealth;
            }
            else if (_currentValue > _maximumValue)
            {
                _currentValue = _maximumValue;
            }
        }
    }
}
