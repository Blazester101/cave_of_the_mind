using UnityEngine;

public class CollisionSFX : MonoBehaviour
{
    public AudioSource playsound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain") //requires 'Terrain' to trigger. Snap Kit will need to be updated if it hasn't already.
        {
            playsound.Play();
        }
    }
}
//might need to add an OR condition to the If statment above to allow for when objects bump into each other.
//tried adding this to TriggerSFX, but strange interaction made it so the sound played even when hitting triggers when it shouldn't.
//isolating this script to keep everything from being too complicated