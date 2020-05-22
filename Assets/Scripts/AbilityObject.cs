using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Custom/Ability")]
public class AbilityObject : ScriptableObject
{
    public string Name;
    public string LatinName;
    [TextArea]
    public string Description;
    public Sprite Icon;
}
