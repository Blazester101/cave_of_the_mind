using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    Animator buttonAnim;
    public GameObject buttonMesh;

    public ObjectDetectionTrigger objectDetectionTrigger;

    public delegate void ButtonPressed(GameObject button);
    public event ButtonPressed pressedEvent;
    public delegate void ButtonReleased(GameObject button);
    public event ButtonReleased releasedEvent;
    public bool isPressed;
    private bool isForcedPressed = false;
    private List<GameObject> pressers;

    private void Start()
    {
        if (objectDetectionTrigger == null) throw new System.Exception("No objectDetectionTrigger associated with " + gameObject);

        buttonAnim = GetComponent<Animator>();
        buttonAnim.speed = 2.0f;

        objectDetectionTrigger.enterEvent += buttonPressedby;
        objectDetectionTrigger.exitEvent += buttonReleasedby;

        isPressed = buttonAnim.GetCurrentAnimatorStateInfo(0).IsName("Pressed");
        pressers = new List<GameObject>();
    }

    private void Update()
    {
        if (isForcedPressed) return;

        if (pressers.Count > 0)
        {
            if (!isPressed)
            {
                isPressed = true;
                if (pressedEvent != null) pressedEvent(gameObject);
                if (buttonAnim != null) animateButtonDown();
            }
        }
        else
        {
            if (isPressed)
            {
                isPressed = false;
                if (releasedEvent != null) releasedEvent(gameObject);
                if (buttonAnim != null) animateButtonUp();            
            }
        }
    }

    public void Press()
    {
        isForcedPressed = true;
        if (pressedEvent != null && !isPressed) pressedEvent(gameObject);
        if (buttonAnim != null && !isPressed) animateButtonDown();
        isPressed = true;
    }
    public void Release()
    {
        isForcedPressed = false;
        //if (releasedEvent != null && isPressed) releasedEvent(gameObject);
        //if (buttonAnim != null && isPressed) animateButtonUp();
        //isPressed = false;
    }

    void buttonPressedby(GameObject obj)
    {
        if(obj != buttonMesh) pressers.Add(obj);
    }
    void buttonReleasedby(GameObject obj)
    {
        pressers.Remove(obj);
    }

    void animateButtonDown()
    {
        buttonAnim.ResetTrigger("Unpressed");
        buttonAnim.SetTrigger("Pressed");

    }
    void animateButtonUp()
    {
        buttonAnim.ResetTrigger("Pressed");
        buttonAnim.SetTrigger("Unpressed");
    }
}

public interface ITriggeredByButton
{
    void onButtonPressed(GameObject button);
    void onButtonReleased(GameObject button);
}
