using UnityEngine;

namespace Platformer2D
{
    public class ConstantsGradient : MonoBehaviour
    {
        [SerializeField] private Gradient _healthBar;
        public Gradient HealthBar { get => _healthBar; }
    }
}
