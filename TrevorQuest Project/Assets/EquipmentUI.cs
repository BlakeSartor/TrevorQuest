using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour {

    public Transform equipmentParent;
    public GameObject equipmentWindow;
    EquipmentManager equipmentManager;
    Equipment[] equipment;

    EquipSlot[] equipSlots;

	// Use this for initialization
	void Start () {
        equipmentManager = EquipmentManager.instance;
        equipmentManager.onEquipmentChanged += UpdateEquipmentUI;

        equipSlots = equipmentParent.GetComponentsInChildren<EquipSlot>();
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        equipment = new Equipment[numSlots];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Equipment"))
        {
            equipmentWindow.SetActive(!equipmentWindow.activeSelf);
        }
    }

    void UpdateEquipmentUI(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null && !newItem.isDefaultItem)
        {
            equipment[(int)newItem.equipSlot] = newItem;
 
            for (int i = 0; i < equipment.Length; i++)
            {
                if (equipment[i] != null)
                { 
                        equipSlots[i].AddItem(equipment[i]);

                }
            }
        }
        else if (newItem == null)
        {
            for(int i=0; i < equipment.Length; i++)
            {
                Debug.Log("Clearing SLots....");
                equipSlots[i].ClearSlot();
            }
        }
        else if (oldItem != null)
        {
            Debug.Log("here");
        }
        else if (oldItem == null)
        {
            for(int i = 0; i < equipment.Length; i++)
            {
                equipment[i] = null;
            }
            Debug.Log("oldy is null");
        }
              
    }
}
