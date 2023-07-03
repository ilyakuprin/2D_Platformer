using UnityEngine;
using System.Collections;

namespace JumpOrDie
{
    public abstract class MeleeAttack : Attacks
    {
        protected bool canAttack = true;

        protected override IEnumerator Recharge()
        {
            float _timerRechargeTime = rechargeTime;
            canAttack = false;
            while (_timerRechargeTime > 0)
            {
                _timerRechargeTime -= Time.deltaTime;
                yield return null;
            }
            canAttack = true;
        }
    }
}
