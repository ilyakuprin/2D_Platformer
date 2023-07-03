using UnityEngine;

namespace JumpOrDie
{
    public class DeathEnemy : HealthChangeVisualization
    {
        [SerializeField] private Behaviour[] _componentsOff;
        [SerializeField] private GameObject _statsCanvas;

        public void Die()
        {
            GetAnimator.SetBool(hashAnimations.Death, true);
            _statsCanvas.SetActive(false);

            for (int i = 0; i < _componentsOff.Length; i++)
            {
                Destroy(_componentsOff[i]);
            }
        }
    }
}
