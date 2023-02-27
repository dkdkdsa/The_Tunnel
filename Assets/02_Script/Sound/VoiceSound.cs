using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceSound : MonoBehaviour
{

    [SerializeField] private AudioClip coughSound;
    [SerializeField] private AudioClip breathSound;

    private bool play;
    private AudioSource source;
    private PlayerO2 playerO2;

    private void Awake()
    {
        
        source = GetComponent<AudioSource>();
        playerO2 = FindObjectOfType<PlayerO2>();

    }

    private void Update()
    {
        
        if(playerO2.isIn == true && play == false && source.isPlaying == false)
        {

            source.clip = coughSound;
            play = true;
            source.Play();

        }
        else if(playerO2.isIn == false && play == true && source.isPlaying == false)
        {

            source.clip = breathSound;
            play = false;
            source.Play();

        }

    }

}
