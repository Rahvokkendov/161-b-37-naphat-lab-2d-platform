using UnityEngine;
using UnityEngine.UI;

public class HealthBarUi : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealt(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
