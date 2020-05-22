using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Ability List")]
public class AbilityList : ScriptableObject
{
    public List<AbilityObject> Abilities = new List<AbilityObject>();
}
