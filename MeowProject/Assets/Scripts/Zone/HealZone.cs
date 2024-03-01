using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour
{
    public int heal = 10;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            stats.Heal(heal);
            Debug.Log(other.name + " GetDamage " + heal.ToString());
        }
    }
}
