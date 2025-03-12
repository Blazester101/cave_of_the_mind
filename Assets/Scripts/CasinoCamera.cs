using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasinoCamera : MonoBehaviour
{
    public GameObject _casinoCameraBody;
    public GameObject _casinoSpotLight;
    public GameObject _casinoOutOfBounds;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Camera Break");
        if (other.tag == "Interactable") //Not necessary in 99% of cases, but keeping if statement here on the off chance player manages to touch the collider themselves. This ensures that it must be an 'interactable' object.
        {
            Rigidbody rg = _casinoCameraBody.GetComponent<Rigidbody>();
            rg.useGravity = true; //Causes object to drop from where it was.

            Destroy(_casinoSpotLight); //Light shows where player can't go. Could be fun to let player run around with a giant flashlight, but no.

            Destroy(_casinoOutOfBounds); //Destroys out of bounds so player can progress without issue.

            
        }

    }
}

