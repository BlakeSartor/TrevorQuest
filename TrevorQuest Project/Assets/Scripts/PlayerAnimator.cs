using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharacterAnimator {

    public WeaponAnimations[] weaponAnimations;
    Dictionary<Equipment, AnimationClip[]> weaponAnimationsDict;

    protected override void Start()
    {
        base.Start();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

        weaponAnimationsDict = new Dictionary<Equipment, AnimationClip[]>();
        foreach (WeaponAnimations a in weaponAnimations)
        {
            weaponAnimationsDict.Add(a.weapon, a.clips);
        }
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem) 
    {
        if (newItem != null && newItem.equipSlot == EquipmentSlot.Primary)
        {
            animator.SetLayerWeight(1, 1);
            if (weaponAnimationsDict.ContainsKey(newItem))
            {
                currentAttackAnimSet = weaponAnimationsDict[newItem];
            }

        }
        else if(newItem == null && oldItem != null && oldItem.equipSlot == EquipmentSlot.Primary)
        {
            animator.SetLayerWeight(1, 0);
            currentAttackAnimSet = defaultAttackAnimSet;
        }
    }

    [System.Serializable]
    public struct WeaponAnimations
    {
        public Equipment weapon;
        public AnimationClip[] clips;
    }
}
