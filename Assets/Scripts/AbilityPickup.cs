using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class AbilityPickup : MonoBehaviour
{
    public AbilityList PlayerAbilities;
    public AbilityObject GrantedAbility;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerAbilities.Abilities.Add(GrantedAbility);
            Destroy(this.gameObject);
        }
    }
}
