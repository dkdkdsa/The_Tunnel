using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : UIToolKitRoot
{

    [SerializeField] private Transform dropPos;
    private bool isOpen;
    private VisualElement inventoryBG;
    private List<Slot> slots = new List<Slot>();
    private PlayerMove playerMove;
    private CameraRotate rotate;
    private bool isFull;

    private void Awake()
    {
        
        rotate = FindObjectOfType<CameraRotate>();
        playerMove = FindObjectOfType<PlayerMove>();

    }

    protected override void OnEnable()
    {

        base.OnEnable();

        inventoryBG = rootElement.Q("BG");
        inventoryBG.Query<VisualElement>("Slot").ToList().ForEach(x =>
        {

            slots.Add(new Slot { slotElement = x });

        });

    }

    private void Update()
    {

        Open();

    }

    private void Open()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {

            if (isOpen)
            {

                inventoryBG.RemoveFromClassList("open");
                isOpen = false;

                playerMove.moveAble = true;
                rotate.rotateAble = true;

            }
            else
            {

                inventoryBG.AddToClassList("open");
                isOpen = true;

                playerMove.moveAble = false;
                rotate.rotateAble = false;

            }

        }

    }

    public bool SetSlot(ICollectionAbleItem item)
    {

        if (!isFull)
        {

            var slot = slots.Find(x => x.isSet == false);

            if (slot == null) return false;

            slot.isSet = true;
            slot.itemName = item.itemName;
            slot.useAction = item.InventoryUseEvent;
            slot.itemObj = item.itemGameObject;
            slot.slotElement.style.backgroundImage = new StyleBackground(item.itemSprite);

            EventCallback<MouseDownEvent> evt = (x) => { };

            evt = (x) =>
            {

                if (x.button == 0)
                {

                    slot.isSet = false;
                    slot.useAction();
                    slot.itemName = "";
                    slot.slotElement.style.backgroundImage = null;
                    slot.slotElement.UnregisterCallback(evt);

                }
                else if(x.button == 1)
                {

                    slot.isSet = false;
                    FAED.Pop(slot.itemObj, dropPos.position, Quaternion.identity);
                    slot.itemName = "";
                    slot.slotElement.style.backgroundImage = null;
                    slot.slotElement.UnregisterCallback(evt);

                }

                slot.crtEvt = evt;

            };


            slot.slotElement.RegisterCallback(evt);

            return true;

        }

        return false;

    }


    public bool UseInventoryItem(string itemName, bool eventAble = false)
    {

        var item = slots.Find(x => x.itemName == itemName);

        if(item != null)
        {

            if (eventAble)
            {

                item.useAction();
                item.isSet = false;
                item.useAction();
                item.itemName = "";
                item.slotElement.style.backgroundImage = null;
                item.slotElement.UnregisterCallback(item.crtEvt);

            }
            else
            {

                item.isSet = false;
                item.itemName = "";
                item.slotElement.style.backgroundImage = null;
                item.slotElement.UnregisterCallback(item.crtEvt);

            }

            return true;

        }

        return false;

    }

}
