using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLight : MonoBehaviour
{

    [SerializeField] private GameObject handLight;

    private bool on;

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.F))
        {

            if (on)
            {

                handLight.SetActive(false);
                on = false;

            }
            else
            {

                handLight.SetActive(true);
                on = true;

            }

        }


    }

}
