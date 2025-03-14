using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Item_Dead_Zone : MonoBehaviour
{
    private ItemRespawnPoint startpoint; //necessary to code, not sure why. Declares variable?

    private void OnTriggerEnter(Collider other)
    { 
        Debug.Log("Out Of Bounds");
        if (other.tag == "Interactable")
        {
            startpoint = other.GetComponent<ItemRespawnPoint>();//this allows 'startpoint' to call on method in other script

            Rigidbody rg = other.GetComponent<Rigidbody>();
            if (rg != null)
            {
                other.transform.position = startpoint.GetStartLocation();//returns the stored information in the item
                rg.linearVelocity = Vector3.zero;
                rg.angularVelocity = Vector3.zero;
            }

        }
    }
}