using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{

    public bool isGround { get; private set; }

    private void OnTriggerEnter(Collider other)
    {

        isGround = true;

    }

    private void OnTriggerStay(Collider other)
    {

        isGround = true;

    }

    private void OnTriggerExit(Collider other)
    {

        isGround = false;

    }

}
