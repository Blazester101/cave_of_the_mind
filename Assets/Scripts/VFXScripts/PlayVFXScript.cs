using UnityEngine;
using UnityEngine.Events;

public class PlayVFXScript : MonoBehaviour
{

    public delegate void PlayVFXEvent(Transform pos);
    public static event PlayVFXEvent triggerVFX;

    public static UnityEvent<Transform> unityTriggerVFX = new UnityEvent<Transform>();

    //Reference to an existing particle prefab
    [SerializeField] private ParticleSystem particleSystem;

    //References each particle system instance spawned into a scene
    private ParticleSystem particleSystemInstance;

    //Reference Object Detection Trigger Script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        triggerVFX += TriggerVFX;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TriggerVFX(Transform pos) {
        
    }
}
