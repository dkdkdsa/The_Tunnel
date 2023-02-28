using FD.Dev;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurvivalValue : MonoBehaviour
{

    [SerializeField] private AudioSource source;

    private const int maxValue = 100;
    private bool isDie;
    private PlayerMove playerMove;
    private CameraEvent cameraEvent;
    private CameraRotate cameraRotate;

    public int hp { get; private set; } = maxValue;
    public int o2 { get; private set; } = maxValue;
    public int food { get; private set; } = maxValue;
    public int water { get; private set; } = maxValue;

    private void Awake()
    {
        
        playerMove = FindObjectOfType<PlayerMove>();
        cameraEvent = FindObjectOfType<CameraEvent>();
        cameraRotate = FindObjectOfType<CameraRotate>();

    }

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

        if(hp == 0 && isDie == false)
        {

            isDie = true;
            playerMove.moveAble = false;
            cameraEvent.eventAble = false;
            cameraRotate.rotateAble = false;
            source.Play();

            FAED.InvokeDelay(() =>
            {

                SceneManager.LoadScene("Start");

            }, 3f);

        }

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

            yield return new WaitForSecondsRealtime(2f);
            if(food == 0)
            {

                hp -= 1;

            }

            if(water == 0)
            {

                hp -= 1;

            }

            Drawoff(ValueType.Water, 1);
            Drawoff(ValueType.Food, 1);


            yield return null;

        }

    }

}
