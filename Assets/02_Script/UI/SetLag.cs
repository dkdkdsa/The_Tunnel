using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetLag : MonoBehaviour
{

    private TMP_Dropdown dropdown;

    private void Awake()
    {
        
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.value = PlayerPrefs.GetInt("V");

    }

    private void OnDisable()
    {
        
        PlayerPrefs.SetString("Lag", dropdown.captionText.text);
        PlayerPrefs.SetInt("V", dropdown.value);

    }

}
