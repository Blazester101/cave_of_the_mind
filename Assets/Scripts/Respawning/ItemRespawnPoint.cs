using UnityEngine;

public class ItemRespawnPoint : MonoBehaviour
{
    public Vector3 startlocation;

    void Start()//saves the initial start location as the game starts in 'startlocation'
    {
        startlocation = transform.position;
    }

    public Vector3 GetStartLocation()//method to return the startlocation when called on
    {
        return startlocation;
    }
}