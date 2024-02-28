using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int HealthPoints = 80;
    private int MaxHealthPoints = 140;

    public void Damage(int damage)
    {
        if (damage < 0) { damage = 0; }
        HealthPoints = Mathf.Clamp(HealthPoints - damage, 0, MaxHealthPoints);
    }

    public void Heal(int heal)
    {
        if (heal < 0) { heal = 0; }
        HealthPoints = Mathf.Clamp(HealthPoints + heal, 0, MaxHealthPoints);
    }
}
