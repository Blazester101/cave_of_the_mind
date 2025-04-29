using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour, IInteractable
{
    private float maxInteractionDistance = 3;
    private bool canBeInteractedWith = false;
    private Outline outlineEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        outlineEffect = GetComponent<Outline>();
        if (outlineEffect != null)
        {
            outlineEffect.OutlineColor = Interact.outlineColor;
            outlineEffect.OutlineWidth = Interact.outlineWidth;
            outlineEffect.OutlineMode = Interact.outlineMode;
            outlineEffect.enabled = false;
        }
    }
    void Update()
    {
        if (outlineEffect != null)
        {
            if (canBeInteractedWith) outlineEffect.enabled = true;
            else outlineEffect.enabled = false;
            canBeInteractedWith = false;
        }
    }

    public bool interactionQuery(float distance)
    {
        canBeInteractedWith = distance < maxInteractionDistance;
        return canBeInteractedWith;
    }

    public void onInteract(InteractEventArgs args)
    {
        SceneManager.LoadScene("Main Menu");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
