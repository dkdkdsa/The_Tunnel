using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSit : MonoBehaviour
{

    [SerializeField] private float sitSpeed;
    [SerializeField] private GameObject cameraObj;
    [SerializeField] private AudioSource source;


    private PlayerMove playerMove;
    private CapsuleCollider capsuleCollider;
    private float originSpeed;
    public bool isSit { get; private set; }

    private void Awake()
    {

        capsuleCollider = GetComponent<CapsuleCollider>();
        playerMove = GetComponent<PlayerMove>();
        originSpeed = playerMove.GetSpeed();

    }

    private void Update()
    {

        Sit();

    }

    private void Sit()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isSit)
        {

            DOTween.Kill(this);

            isSit = true;
            capsuleCollider.height = 1;
            capsuleCollider.center = new Vector3(0, -0.35f, 0);
            cameraObj.transform.DOLocalMoveY(0, 0.1f);
            playerMove.SetSpeed(sitSpeed);
            source.volume = 0.3f;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && isSit)
        {

            DOTween.Kill(this);

            isSit = false;
            capsuleCollider.height = 2;
            capsuleCollider.center = new Vector3(0, 0f, 0);
            cameraObj.transform.DOLocalMoveY(0.7f, 0.1f);
            playerMove.SetSpeed(originSpeed);

            source.volume = 1f;

        }

    }

}
