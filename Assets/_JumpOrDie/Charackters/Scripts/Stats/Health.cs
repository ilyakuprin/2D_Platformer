namespace JumpOrDie
{
    public class Health : Stats
    {
        private readonly int _minimumHealth = 1;

        private void Start()
        {
            if (CurrentValue < MaximumValue && CurrentValue > 0)
            {
                GetComponent<HealthChange>().ChangeHealBar(CurrentValue, MaximumValue);
            }
        }

        public bool Dead()
        {
            if (CurrentValue <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void OnValidate()
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
