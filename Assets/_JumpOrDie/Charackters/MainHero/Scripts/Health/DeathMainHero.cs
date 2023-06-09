using System.Collections;
using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(LastSavePosition), typeof(Health), typeof(UIFieldsMainHero))]
    [RequireComponent(typeof(TakingDamage))]
    public class DeathMainHero : HealthChangeVisualization
    {
        [SerializeField] private GameObject _canvasDeath;
        [SerializeField] private float _timeAfterDeath;
        [SerializeField] private Behaviour[] _componentsOff;
        private LastSavePosition _lastSavePosition;
        private UIFieldsMainHero _uiFieldsMainHero;

        protected override void Awake()
        {
            base.Awake();
            _lastSavePosition = GetComponent<LastSavePosition>();
            _uiFieldsMainHero = GetComponent<UIFieldsMainHero>();
        }

        public void Die()
        {
            if (GetHealth.Dead())
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<AudioSource>().Play();

                _uiFieldsMainHero.HeartController.SubtractHeart();
                StartCoroutine(Death());
            }
        }

        private IEnumerator Death()
        {
            GetUIFields.HealthBar.fillAmount = 0;
            EnDisComponents(true);

            if (_timeAfterDeath > 0)
            {
                yield return new WaitForSeconds(_timeAfterDeath);
            }

            if (_uiFieldsMainHero.HeartController.CountHearth > 0)
            {
                Res();
            }
            else
            {
                FinalDeath();
            }
        }

        private void Res()
        {
            GetUIFields.HealthBar.fillAmount = 1;
            EnDisComponents(false);
            transform.position = _lastSavePosition.SavePosition;
            GetHealth.Increase(GetHealth.MaximumValue);

            GetComponent<DamageReceived>().ChangeHealBar();
        }

        private void FinalDeath()
        {
            _canvasDeath.SetActive(true);
        }

        private void EnDisComponents(bool isDeath)
        {
            GetAnimator.SetBool(hashAnimations.Death, isDeath);
            for (int i = 0; i < _componentsOff.Length; i++)
            {
                _componentsOff[i].enabled = !isDeath;
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
