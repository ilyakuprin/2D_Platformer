namespace Platformer2D
{
    public class DamageReceived : HealthChange
    {
        public void TakeDamage(int currentHealth, int maxHealth)
        {
            ChangeHealBar(currentHealth, maxHealth);
            GetAnimator.SetTrigger(hashAnimations.TakeHit);
        }
    }
}
