using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverText : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DescriptionText;

    public void UpdateText(AbilityObject ability)
    {
        NameText.text = ability.Name + " (" + ability.LatinName + ")";
        DescriptionText.text = ability.Description;
    }
}
