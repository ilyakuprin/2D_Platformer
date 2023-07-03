using UnityEngine;
using UnityEngine.UI;

namespace JumpOrDie
{
    public class UIFields : MonoBehaviour
    {
        [SerializeField] private ConstantsGradient _constantsGradient;
        [SerializeField] private Image _healthBar;

        public ConstantsGradient ConstantsGradient { get => _constantsGradient; }
        public Image HealthBar { get => _healthBar; }

        private void Start()
        {
            int maximumValue = 1;
            _healthBar.color = ConstantsGradient.HealthBar.Evaluate(maximumValue);
        }
    }
}
