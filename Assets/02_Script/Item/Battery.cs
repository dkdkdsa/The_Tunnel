using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour, ICollectionAbleItem
{

    private SurvivalValue survivalValue;

    [field: SerializeField] public Sprite itemSprite { get; set; }

    public bool overlap { get; set; } = false;
    public Inventory inventory { get; set; }
    public string itemName { get; set; } = "Battery";
    public string itemGameObject { get; set; }
    public string itemTextKey { get; set; } = "Item";

    private void Awake()
    {

        survivalValue = FindObjectOfType<SurvivalValue>();
        inventory = FindObjectOfType<Inventory>();
        itemGameObject = "Battery";

    }

    public void InventoryUseEvent()
    {

        //화면흔들리고, 소리나오게

        survivalValue.DrawOff(ValueType.Hp, 10);

    }

    public void UseEvent()
    {

        if (inventory.SetSlot(this))
        {

            FAED.Push(gameObject);

        }

    }
}
