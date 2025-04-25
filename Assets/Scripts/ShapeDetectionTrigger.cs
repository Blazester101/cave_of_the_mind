using UnityEngine;

public class ShapeDetectionTrigger : MonoBehaviour
{
    public ObjectDetectionTrigger objectDetectionTrigger;
    public bool pressButtonWhenCorrectShapeDetected = false;
    public Button buttonToPress;
    public ObjectShape shapeToDetect;
    private bool shapeDetected = false;
    public bool correctShapeDetected = false;
    private ShapedObject shapedObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectDetectionTrigger.enterEvent += ObjectEnteredTrigger;
        objectDetectionTrigger.exitEvent += ObjectExitedTrigger;
        shapedObject = null;
    }

    void ObjectEnteredTrigger(GameObject obj)
    {
        ShapedObject sh = obj.GetComponent<ShapedObject>();
        if (sh != null)
        {
            shapeDetected = true;
            shapedObject = sh;
        }
    }

    void ObjectExitedTrigger(GameObject obj)
    {
        shapeDetected = false;
        shapedObject = null;
    }

    private void Update()
    {
        if (!shapeDetected || shapedObject == null)
        {
            correctShapeDetected = false;
            if (pressButtonWhenCorrectShapeDetected) buttonToPress.Release();
            return;
        }

        correctShapeDetected = shapedObject.objectShape == shapeToDetect;

        if (correctShapeDetected && pressButtonWhenCorrectShapeDetected) buttonToPress.Press();
        else if (!correctShapeDetected && pressButtonWhenCorrectShapeDetected) buttonToPress.Release();
    }
}
