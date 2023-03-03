using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Events;


public class SmallFuseBox : MonoBehaviour, IUseableItem
{

    [SerializeField] private UnityEvent repairEvent;

    private Animator animator;
    private bool isOpen;
    private bool isRepair;
    private Inventory inventory;

    public Sprite itemSprite { get; set; }
    public string itemGameObject { get; set; }
    public string itemTextKey { get; set; }
    public string itemName { get; set; } = "FuseBox";

    private void Awake()
    {

        animator = GetComponent<Animator>();
        inventory = FindObjectOfType<Inventory>();

    }

    private void FixedUpdate()
    {

        if (isRepair)
        {

            itemTextKey = "smallFuseBox(No)";

        }
        else
        {

            itemTextKey = "smallFuseBox";

        }

    }

    public void UseEvent()
    {


        if (inventory.UseInventoryItem("Battery"))
        {

            repairEvent.Invoke();

            gameObject.layer = 0;

        }
        else
        {

            if (isRepair) return;

            isRepair = true;

            FAED.InvokeDelay(() =>
            {

                isRepair = false;

            }, 1f);

        }

    }

}
