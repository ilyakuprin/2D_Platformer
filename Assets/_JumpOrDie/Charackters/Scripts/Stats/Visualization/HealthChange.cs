namespace JumpOrDie
{
    public abstract class HealthChange : HealthChangeVisualization
    {
        public void ChangeHealBar(int currentHealth, int maxHealth)
        {
            float valueCurrentHealth = (float)currentHealth / maxHealth;
            GetUIFields.HealthBar.fillAmount = valueCurrentHealth;
            GetUIFields.HealthBar.color = GetUIFields.ConstantsGradient.HealthBar.Evaluate(valueCurrentHealth);
        }
    }
}
