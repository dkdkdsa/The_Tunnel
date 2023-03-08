using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EdScene : MonoBehaviour
{

    private void Start()
    {

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        FAED.InvokeDelay(() => SceneManager.LoadScene("Start"), 3f);

    }

}
