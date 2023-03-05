using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager
{

    [RuntimeInitializeOnLoadMethod]
    private static void Set()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

}
