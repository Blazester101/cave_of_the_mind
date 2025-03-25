using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
    public AudioSource playsound;
    public bool PlayerOnly;
    public bool ObjectOnly;
    public bool PlayOnlyOnce;
    bool playonce;

    private void Start()
    {
        if (PlayOnlyOnce == true)
        {
            playonce = true; //PlayOnlyOnce uses two booleans to ensure an 'and' activation; so long as both are true, it will play. If one is off but the other is on, it won't.
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (PlayerOnly == true && other.tag == "Player") //Requires the player to trigger
        {
            if (playonce == true && PlayOnlyOnce == true)
            {
                playsound.Play();
                playonce = false;
            }
            else if (PlayOnlyOnce == false) //If PlayOnlyOnce was never turned on, will play normally as many times as the trigger happens.
            {
                playsound.Play();
            }
        }
        else if (ObjectOnly == true && other.tag == "Interactable") //Requires interactables to trigger
        {
            if (playonce == true && PlayOnlyOnce == true)
            {
                playsound.Play();
                playonce = false;
            }
            else if (PlayOnlyOnce == false)
            {
                playsound.Play();
            }
        }
        else if (ObjectOnly == false && PlayerOnly == false) //Removes all requirements for what triggers the sound
        {
            if (playonce == true && PlayOnlyOnce == true)
            {
                playsound.Play();
                playonce = false;
            }
            else if (PlayOnlyOnce == false)
            {
                playsound.Play();
            }
        }
    }
}
