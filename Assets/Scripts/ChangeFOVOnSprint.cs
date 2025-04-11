using Cinemachine;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeFOVOnSprint : MonoBehaviour
{
    public StarterAssetsInputs inputs;
    public CinemachineVirtualCamera virtualCamera;
    public float walkFOV = 90f;
    public float sprintFOV = 110f;
    public float maxLerpStep = 0.05f; // The maximum speed at which the FOV can change

    private float lastLerpVal = 0f;

    // Update is called once per frame
    void Update()
    {
        float lerpVal = lastLerpVal;
        if (inputs.sprint)
        {
            lerpVal = Mathf.Clamp(lastLerpVal + maxLerpStep, 0, 1);
        }
        else
        {
            lerpVal = Mathf.Clamp(lastLerpVal - maxLerpStep, 0, 1);
        }

        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(walkFOV, sprintFOV, lerpVal);

        lastLerpVal = lerpVal;
    }
}
