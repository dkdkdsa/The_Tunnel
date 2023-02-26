using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalValue : MonoBehaviour
{

    private const int maxValue = 100;

    public int hp { get; private set; } = 15;
    public int o2 { get; private set; } = maxValue;
    public int food { get; private set; } = maxValue / 2;
    public int water { get; private set; } = maxValue / 2;

    private void Start()
    {

        StartCoroutine(lifeActivity());

    }

    private void Update()
    {
        
        hp = Mathf.Clamp(hp, 0, maxValue);
        food = Mathf.Clamp(food, 0, maxValue);
        water = Mathf.Clamp(water, 0, maxValue);
        o2 = Mathf.Clamp(o2, 0, maxValue);

    }

    public void Drawoff(ValueType type, int value)
    {

        Action action = type switch
        {

            ValueType.Hp => () => hp -= value,
            ValueType.Water => () => water -= value,
            ValueType.Food => () => food -= value,
            ValueType.O2 => () => o2 -= value,
            _ => null

        };

        action?.Invoke();

    }

    public void AddValue(ValueType type, int value)
    {

        Action action = type switch
        {

            ValueType.Hp => () => hp += value,
            ValueType.Water => () => water += value,
            ValueType.Food => () => food += value,
            ValueType.O2 => () => o2 += value,
            _ => null

        };

        action?.Invoke();

    }

    IEnumerator lifeActivity()
    {

        while (true)
        {

            yield return new WaitForSecondsRealtime(5f);
            Drawoff(ValueType.Water, 1);
            Drawoff(ValueType.Food, 1);

            if(food == 0)
            {

                hp -= 1;

            }

            if(water == 0)
            {

                hp -= 1;

            }

            yield return null;

        }

    }

}
