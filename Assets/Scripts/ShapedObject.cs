using UnityEngine;

public class ShapedObject : MonoBehaviour
{
    public ObjectShape objectShape;
    private ShiftableObject shiftableComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shiftableComponent = GetComponent<ShiftableObject>();
        if (shiftableComponent != null) objectShape = shiftableComponent.startingType;
    }

    private void Update()
    {
        if(shiftableComponent != null) objectShape = shiftableComponent.currentType;
    }
}
