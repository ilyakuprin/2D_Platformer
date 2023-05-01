namespace Platformer2D
{
    public class Health : Stats
    {
        private readonly int _minimumHealth = 1;

        protected virtual void Start()
        {
            if (CurrentValue < MaximumValue && CurrentValue > 0)
            {
                GetComponent<HealthChange>().ChangeHealBar(CurrentValue, MaximumValue);
            }
        }

        protected virtual void OnValidate()
        {
            if (CurrentValue < _minimumHealth)
            {
                CurrentValue = _minimumHealth;
            }
            else if (CurrentValue > MaximumValue)
            {
                CurrentValue = MaximumValue;
            }
        }
    }
}
