using System.Collections;
using UnityEngine;

namespace Platformer2D
{
    public abstract class Attacks : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 2)] protected float attackRadius;
        [SerializeField] protected Transform attackPoint;
        [SerializeField] protected float rechargeTime;
        [SerializeField] protected int attackPower;
        [SerializeField] protected LayerMask enemy;
        protected Collider2D _enemy;

        public Collider2D Player { get => _enemy; }

        protected abstract IEnumerator Recharge();

        protected virtual void Awake()
        {
            if (attackPoint == null)
                attackPoint = transform;

            var hashLayers = new HashLayers();

            if (enemy == hashLayers.Nothing)
            {
                enemy = hashLayers.Player;
            }
        }

        protected virtual void FixedUpdate()
        {
            _enemy = Physics2D.OverlapCircle(attackPoint.position, attackRadius, enemy);
        }

        protected virtual void OnValidate()
        {
            if (rechargeTime < 0)
                rechargeTime = 0;

            if (attackPower < 0)
                attackPower = 1;
        }

        protected void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        }

    }
}
