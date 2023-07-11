using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(Health))]
    public class TakingDamage : MonoBehaviour
    {
        public delegate void IsTakingDamage();
        public event IsTakingDamage TookDamage;

        private Health _health;

        protected virtual void Awake()
        {
            _health = GetComponent<Health>();
        }

        public void TakeDamage(int damage)
        {
            _health.Reduce(damage);
            TookDamage?.Invoke();
        }
    }
}
