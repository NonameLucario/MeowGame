using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            stats.Damage(damage);
            Debug.Log(other.name + " GetDamage " + damage.ToString());
        }
    }
}
