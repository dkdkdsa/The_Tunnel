using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraEvent : UIToolKitRoot
{

    [SerializeField] private float range = 3f;

    private IItem currentObj;
    private Label text;
    public bool eventAble = true;

    protected override void OnEnable()
    {

        base.OnEnable();

        text = rootElement.Q<Label>("Text");

    }

    private void Update()
    {

        Range();

    }

    private void Range()
    {

        if (!eventAble) return;

        bool objAble = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range, LayerMask.GetMask("Item"));

        if(objAble)
        {

            if(currentObj == null)
            {

                currentObj = hit.transform.GetComponent<IItem>();

            }

            text.text = Manager.Managers.GetText(currentObj.itemTextKey);

            if (Input.GetKeyDown(KeyCode.E))
            {

                if (hit.transform.CompareTag("InventoryItem"))
                {

                    var item = hit.transform.GetComponent<ICollectionAbleItem>();

                    item.UseEvent();

                }
                else if (hit.transform.CompareTag("UseItem"))
                {

                    var item = hit.transform.GetComponent<IUseableItem>();

                    item.UseEvent();

                }

            }

        }
        else
        {

            currentObj = null;
            text.text = "";

        }

    }

}
