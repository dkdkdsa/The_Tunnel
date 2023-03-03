using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;

public interface IItem
{

    public string itemName { get; set; }
    public Sprite itemSprite { get; set; }
    public string itemGameObject { get; set; }
    public string itemTextKey { get; set; }

}

public interface IUseableItem : IItem
{

    public void UseEvent();

}

public interface ICollectionAbleItem : IUseableItem
{

    public bool overlap { get; set; }
    public Inventory inventory { get; set; }
    public void InventoryUseEvent();


}