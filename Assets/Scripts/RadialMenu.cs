using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RadialMenu : MonoBehaviour
{
    private Camera MainCamera;

    private RadialItem[] Items;
    public AbilityEvent SelectedEvent;

    public AbilityList UnlockedAbilities;

    public GameObject Background;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = FindObjectOfType<Camera>();
        Items = GetComponentsInChildren<RadialItem>();
        foreach (RadialItem item in Items)
        {
            item.gameObject.SetActive(false);
        }
        Background.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if e key is pressed, get mouse position, set position to mouse position, enable children
        //if e key is released, get selected child, pass selected ability back in event

        if (Input.GetKeyDown(KeyCode.E))
        {
            Show();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            Hide();
        }
    }

    void Show()
    {
        Background.SetActive(true);

        Vector3 mousePosition = Input.mousePosition;
        Vector3 Worldposition = MainCamera.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(Worldposition.x, Worldposition.y, 0);

        foreach (RadialItem item in Items)
        {
            if (UnlockedAbilities.Abilities.Contains(item.Ability))
            {
                item.gameObject.SetActive(true);
            }
        }
    }

    void Hide()
    {
        Background.SetActive(false);

        foreach (RadialItem item in Items)
        {
            item.gameObject.SetActive(false);
            if (item.Selected)
            {
                SelectedEvent.Invoke(item.Ability);
                item.Selected = false;
            }
            item.image.color = Color.gray;
            item.hover.gameObject.SetActive(false);
        }
    }
}
