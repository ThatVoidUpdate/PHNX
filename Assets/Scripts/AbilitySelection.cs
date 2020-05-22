using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelection : MonoBehaviour
{
    private List<Ability> AbilityComponents = new List<Ability>();
    public string AbilityControl;
    private float OldInputState = 0;


    // Start is called before the first frame update
    void Start()
    {
        //find all ability on this object
        //store them
        MonoBehaviour[] monoBehaviours = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour mono in monoBehaviours)
        {
            if (mono is Ability)
            {
                AbilityComponents.Add((Ability)mono);
                mono.enabled = false;
            }
        }

        print(AbilityComponents);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(AbilityControl) == 1 && OldInputState == 0)
        {
            print("Using Ability");
            foreach (Ability ability in AbilityComponents)
            {
                if (ability.enabled == true)
                {
                    ability.OnUseAbility();
                }
            }
            OldInputState = 1;
        }
        else if (Input.GetAxis(AbilityControl) == 0 && OldInputState == 1)
        {
            print("Un-using ability");
            foreach (Ability ability in AbilityComponents)
            {
                if (ability.enabled == true)
                {
                    ability.OnStopUseAbility();
                }
            }
            OldInputState = 0;
        }
    }

    public void ChangeAbility(AbilityObject ability)
    {
        //find the ability that has that referenced object stored on it
        //enable it
        //disable the others
        foreach (Ability abilityComponent in AbilityComponents)
        {
            if (abilityComponent.SO == ability)
            {
                abilityComponent.enabled = true;
            }
            else
            {
                abilityComponent.enabled = false;
            }
        }
    }
}
