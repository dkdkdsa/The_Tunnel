using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuseBox : MonoBehaviour, IUseableItem
{

    private const string nonOpenFuseBoxKey = "FuseBox(NoOpen)";
    private const string openFuseBoxKey = "FuseBox(Open)";
    private const string noRepairFuseBox = "FuseBox(No)";

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
        
        if(isOpen == false)
        {

            itemTextKey = nonOpenFuseBoxKey;

        }
        else
        {

            if (isRepair)
            {

                itemTextKey = noRepairFuseBox;

            }
            else
            {

                itemTextKey = openFuseBoxKey;

            }


        }

    }

    public void UseEvent()
    {
        
        if(isOpen == false)
        {

            animator.SetTrigger("openDoor");
            isOpen = true;

        }
        else
        {

            if (inventory.UseInventoryItem("Tape"))
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
}
