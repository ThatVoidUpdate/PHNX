using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class RadialItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AbilityObject Ability;
    [HideInInspector]
    public Image image;
    public bool Selected = false;
    public HoverText hover;

    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = Ability.Icon;
        image.color = Color.gray;
        hover.UpdateText(Ability);
        hover.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Selected = true;
        image.color = Color.white;
        hover.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Selected = false;
        image.color = Color.gray;
        hover.gameObject.SetActive(false);
    }
}
