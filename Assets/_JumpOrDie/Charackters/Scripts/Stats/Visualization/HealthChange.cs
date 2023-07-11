namespace JumpOrDie
{
    public abstract class HealthChange : HealthChangeVisualization
    {
        public void ChangeHealBar()
        {
            float valueCurrentHealth = (float)GetHealth.CurrentValue / GetHealth.MaximumValue;
            GetUIFields.HealthBar.fillAmount = valueCurrentHealth;
            GetUIFields.HealthBar.color = GetUIFields.ConstantsGradient.HealthBar.Evaluate(valueCurrentHealth);
        }
    }
}
