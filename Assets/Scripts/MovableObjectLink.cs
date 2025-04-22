using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


public class MovableObjectLink : MonoBehaviour
{
    public Material lineMaterial;
    public List<MovableObject> linkedObjects;
    private List<LineRenderer> lines;
    public bool reverseDirection = false;
    public MovableObject pickedUpObject = null;
    public MovableObject highlightedObject = null;

    private void Start()
    {
        foreach (MovableObject obj in linkedObjects)
        {
            obj.playerDetectionTrigger.enterEvent += PlayerOnAnyPlatform;
            obj.playerDetectionTrigger.exitEvent += PlayerOffAnyPlatform;
        }

        lines = new List<LineRenderer>();
        for(int i = 0; i < linkedObjects.Count - 1; i++)
        {
            GameObject line = new GameObject("Line" + i);
            var renderer = line.AddComponent<LineRenderer>();
            renderer.material = lineMaterial;
            renderer.enabled = false;
            renderer.positionCount = 2;
            renderer.startWidth = 0.04f;
            renderer.endWidth = 0.04f;
            renderer.startColor = Interact.outlineColor;
            renderer.endColor = Interact.outlineColor;
            lines.Add(renderer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool lookForPickedUpObject = true;
        bool lookForOutlinedObject = true;
        //check if an object is picked up or highlighted
        foreach (MovableObject obj in linkedObjects)
        {
            if (obj.isPickedUp)
            {
                pickedUpObject = obj;
                lookForPickedUpObject = false;
            }
            else if(lookForPickedUpObject) pickedUpObject = null;

            if (obj.isOutlined)
            {
                highlightedObject = obj;
                lookForOutlinedObject = false;
            }
            else if(lookForOutlinedObject) highlightedObject = null;
        }

        //draw lines to other platforms
        int lineIndex = 0;
        if(highlightedObject != null)
        {
            foreach (MovableObject obj in linkedObjects)
            {
                if (obj != highlightedObject)
                {
                    //draw line
                    lines[lineIndex].SetPosition(0, highlightedObject.transform.position);
                    lines[lineIndex].SetPosition(1, obj.transform.position);
                    lines[lineIndex].enabled = true;
                    lineIndex++;
                }
            }
        }
        else
        {
            foreach (LineRenderer line in lines) line.enabled = false;
        }



        //apply movement to all linked objects
        if (pickedUpObject != null)
        {
            foreach (MovableObject obj in linkedObjects)
            {
                if (obj != pickedUpObject)
                {
                    if (!reverseDirection) obj.setCurrentLerpPosition(pickedUpObject.getCurrentLerpPosition()); //directly apply motion
                    else obj.setCurrentLerpPosition(1 - pickedUpObject.getCurrentLerpPosition()); //reverse the lerp position
                }
            }
        }
    }

    void PlayerOnAnyPlatform()
    {
        //apply player check result to all platforms
        foreach (MovableObject obj in linkedObjects)
        {
            obj.playerDetected();
        }
    }

    void PlayerOffAnyPlatform()
    {
        //apply player check result to all platforms
        foreach (MovableObject obj in linkedObjects)
        {
            obj.playerNotDetected();
        }
    }
}
