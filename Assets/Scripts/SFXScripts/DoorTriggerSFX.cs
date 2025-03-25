using UnityEngine;

public class DoorTriggerSFX : MonoBehaviour
{
    public Door door; // Reference to the Door component
    public AudioSource playsound;
    private bool playonce = true;

    // Update is called once per frame
    void Update()
    {
        if (door != null && door.isOpen && playonce) // Check if door is assigned and isOpen
        {
            playsound.Play();
            playonce = false;
        }
        if (!door.isOpen && playonce == false)
        {
            playonce = true;
            playsound.Stop();
        }
    }
}

