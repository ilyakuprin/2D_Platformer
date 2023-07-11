using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(TakingDamage))]
    public class DeathEnemy : HealthChangeVisualization
    {
        [SerializeField] private Behaviour[] _componentsOff;
        [SerializeField] private GameObject _statsCanvas;

        public void Die()
        {
            if (GetHealth.Dead())
            {
                GetAnimator.SetBool(hashAnimations.Death, true);
                _statsCanvas.SetActive(false);

                for (int i = 0; i < _componentsOff.Length; i++)
                {
                    Destroy(_componentsOff[i]);
                }
            }
        }

        private void OnEnable()
        {
            GetComponent<TakingDamage>().TookDamage += Die;
        }

        private void OnDisable()
        {
            GetComponent<TakingDamage>().TookDamage -= Die;
        }
    }
}
