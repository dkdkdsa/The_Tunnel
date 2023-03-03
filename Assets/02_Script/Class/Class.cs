using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

[System.Serializable]
public class Slot
{

    public string itemName;
    public VisualElement slotElement;
    public bool isSet;
    public Action useAction;
    public string itemObj;
    public EventCallback<MouseDownEvent> crtEvt;

}