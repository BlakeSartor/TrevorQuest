using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharStats))]
public class Npc : Interactable {

    PlayerManager playerManager;
    CharStats myStats;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharStats>();
    }

    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerComabt = playerManager.player.GetComponent<CharacterCombat>();

        if (playerComabt != null)
        {
            playerComabt.Attack(myStats);
        }
    }
   
}
