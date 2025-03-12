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
        if (other.tag == "Interactable")
        {
            Rigidbody rg = _casinoCameraBody.GetComponent<Rigidbody>();
            rg.useGravity = true;

            Destroy(_casinoSpotLight);

            Destroy(_casinoOutOfBounds);

            
        }

    }
}

