using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


public class MovableObjectLink : MonoBehaviour
{
    public List<MovableObject> linkedObjects;
    public bool reverseDirection = false;
    public MovableObject pickedUpObject = null;

    // Update is called once per frame
    void Update()
    {
        //check if an object is picked up
        foreach(MovableObject obj in linkedObjects)
        {
            if (obj.isPickedUp)
            {
                pickedUpObject = obj;
                break;
            }
            else pickedUpObject = null;
        }

        //apply movement to all linked objects
        if(pickedUpObject != null)
        {
            foreach (MovableObject obj in linkedObjects)
            {
                if (obj != pickedUpObject)
                {
                    if(!reverseDirection) obj.setCurrentLerpPosition(pickedUpObject.getCurrentLerpPosition()); //directly apply motion
                    else obj.setCurrentLerpPosition(1 - pickedUpObject.getCurrentLerpPosition()); //reverse the lerp position
                }
            }
        }
    }
}
