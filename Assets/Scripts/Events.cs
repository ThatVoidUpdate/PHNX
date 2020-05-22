using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> { } // Can pass an int as an argument in the event

[System.Serializable]
public class AbilityEvent : UnityEvent<AbilityObject> { } // Can pass an Ability SO as an argument in the event