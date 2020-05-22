using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gorse : Ability
{
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnStopUseAbility()
    {
        player.JumpForce = 7;
    }

    public override void OnUseAbility()
    {
        print("Using Gorse");
        player.JumpForce = 10;
    }
}
