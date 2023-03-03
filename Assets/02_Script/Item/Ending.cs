using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour, IUseableItem
{
    public Sprite itemSprite { get; set; }
    public string itemGameObject { get; set; }
    public string itemTextKey { get; set; } = "Door";
    public string itemName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void UseEvent()
    {

        SceneManager.LoadScene("Ending");

    }
}
