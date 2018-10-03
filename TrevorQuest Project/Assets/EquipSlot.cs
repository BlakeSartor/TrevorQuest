using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{

    public Image icon;

    Equipment equip;

    public void AddItem(Equipment newItem)
    {
        equip = newItem;

        icon.sprite = equip.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        equip = null;

        icon.sprite = null;
        icon.enabled = false;
        
    }

    public void UseItem()
    {
        if (equip != null)
        {
            equip.Use();
        }
    }
}
