using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Ability List")]
public class AbilityList : ScriptableObject
{
    public List<AbilityObject> Abilities;

    private void OnEnable()
    {
        Abilities = new List<AbilityObject>();
    }
}
