using UnityEngine;

namespace JumpOrDie
{
    public class ConstantsGradient : MonoBehaviour
    {
        [SerializeField] private Gradient _healthBar;
        public Gradient HealthBar { get => _healthBar; }
    }
}
