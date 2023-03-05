using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UseItem : MonoBehaviour, IUseableItem
{

    [SerializeField] private UnityEvent useAction;

    [field: SerializeField] public string itemTextKey { get; set; }
    public string itemName { get; set; }
    public Sprite itemSprite { get; set; }
    public string itemGameObject { get; set; }


    public void UseEvent()
    {
        
        useAction?.Invoke();
        gameObject.layer = 0;

    }

}
