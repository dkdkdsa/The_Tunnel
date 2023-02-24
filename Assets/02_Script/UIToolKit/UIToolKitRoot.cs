using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIToolKitRoot : MonoBehaviour
{

    [SerializeField] protected UIDocument document;

    protected VisualElement rootElement;

    protected virtual void OnEnable()
    {

        rootElement = document.rootVisualElement;

    }

}
