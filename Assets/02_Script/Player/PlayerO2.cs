using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerO2 : MonoBehaviour
{

    public bool isIn { get; private set; }
    private SurvivalValue survival;

    private void Awake()
    {

        survival = FindObjectOfType<SurvivalValue>();

    }

    private void Start()
    {

        StartCoroutine(UpdateCo());

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.transform.CompareTag("Toxic"))
        {

            isIn = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.transform.CompareTag("Toxic"))
        {

            isIn = false;

        }

    }


    IEnumerator UpdateCo()
    {

        while (true)
        {

            yield return new WaitForSeconds(1f);

            if (isIn)
            {

                survival.DrawOff(ValueType.O2, 1);
                if(survival.o2 == 0)
                {

                    survival.DrawOff(ValueType.Hp, 1);

                }

            }
            else
            {

                survival.AddValue(ValueType.O2, 1);

            }

        }

    }

}
