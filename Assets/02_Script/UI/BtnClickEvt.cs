using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnClickEvt : MonoBehaviour
{
    
    public void StartBtn()
    {

        SceneManager.LoadScene("MainMap");

    }

    public void ExitBtn()
    {

        Application.Quit();

    }

}
