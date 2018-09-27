using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        // Equip
        // Remove from inventory
        RemoveFromInventory();
    }

}

public enum EquipmentSlot { Head, Chest, Legs, Primary, Secondary, Feet }

public enum EquipmentMeshRegion { Legs, Torso} // Shape Keys
