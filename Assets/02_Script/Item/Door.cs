using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour, IUseableItem
{

    [SerializeField] private UnityEvent customEvent;
    [SerializeField] private float delTime = 5f;

    private AudioSource source;
    private Animator animator;

    public Sprite itemSprite { get; set; }
    public string itemGameObject { get; set; }
    public string itemTextKey { get; set; } = "Door";



    private void Awake()
    {

        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

    }

    public void UseEvent()
    {

        gameObject.layer = 0;
        animator.SetTrigger("openDoor");
        source.Play();

        FAED.InvokeDelayReal(() =>
        {

            customEvent?.Invoke();

        }, delTime);

    }

}
