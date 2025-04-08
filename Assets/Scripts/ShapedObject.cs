using UnityEngine;

public class ShapedObject : MonoBehaviour
{
    public ObjectShape objectShape;
    public bool overrideShiftableShape = false;
    private ShiftableObject shiftableComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (overrideShiftableShape) return;

        shiftableComponent = GetComponent<ShiftableObject>();
        if (shiftableComponent != null) objectShape = shiftableComponent.startingType;
    }

    private void Update()
    {
        if (overrideShiftableShape) return;

        if (shiftableComponent != null) objectShape = shiftableComponent.currentType;
    }
}
