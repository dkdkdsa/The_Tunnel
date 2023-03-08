using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;

public class WalkSound : MonoBehaviour
{

    [SerializeField] private List<AudioClip> soundClips = new List<AudioClip>();

    private AudioSource source;
    private JumpBox jumpBox;
    private PlayerMove playerMove;

    private void Awake()
    {
        
        source = GetComponent<AudioSource>();
        playerMove = FindObjectOfType<PlayerMove>();
        jumpBox = FindObjectOfType<JumpBox>();

    }

    private void Update()
    {
        
        if(playerMove.isMove == true && source.isPlaying == false)
        {

            source.clip = FAED.Random(soundClips);
            source.Play();

        }

    }

}
