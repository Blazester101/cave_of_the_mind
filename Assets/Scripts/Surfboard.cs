using UnityEngine;

public class Surfboard : MonoBehaviour
{
    public ObjectDetectionTrigger playerDetectionTrigger;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(playerDetectionTrigger != null) {
            
            playerDetectionTrigger.inTriggerEvent += applyVelocity;

        }
    }

    void applyVelocity(GameObject obj) { 
        
        if(obj.tag == "Player") {
            obj.transform.root.position += GetComponent<Rigidbody>().linearVelocity;
        }
        
    }
}
