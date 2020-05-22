using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public AbilityObject SO;

    public abstract void OnUseAbility();
    public abstract void OnStopUseAbility();
}
