using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AID : MonoBehaviour, ICollectionAbleItem
{

    [field: SerializeField] public Sprite itemSprite { get; set; }
    [field: SerializeField] public string itemGameObject { get; set; }
    [field: SerializeField] public string itemTextKey { get; set; }

    private SurvivalValue survivalValue;

    public bool overlap { get; set; } = false;
    public Inventory inventory { get; set; }
    public string itemName { get; set; } = "AID";

    private void OnEnable()
    {

        if (inventory != null && survivalValue != null) return;

        inventory = FindObjectOfType<Inventory>();
        survivalValue = FindObjectOfType<SurvivalValue>();

    }

    public void InventoryUseEvent()
    {

        survivalValue.AddValue(ValueType.Hp, 30);

    }

    public void UseEvent()
    {

        if (inventory.SetSlot(this))
        {

            FAED.Push(gameObject);

        }

    }

}
