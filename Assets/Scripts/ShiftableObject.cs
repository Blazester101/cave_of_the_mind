//using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShiftableObject : MonoBehaviour
{
    public static KeyCode obj1Key = KeyCode.Alpha1;
    public static KeyCode obj2Key = KeyCode.Alpha2;
    public static KeyCode obj3Key = KeyCode.Alpha3;
    public static KeyCode obj4Key = KeyCode.Alpha4;

    public Mesh coreMesh;
    public Mesh cubeMesh;
    public Mesh sphereMesh;
    public Mesh tetrahedronMesh;

    public ObjectShape startingType;
    public ObjectShape currentType;

    public Material[] materials;

    PickupableObject pickupableObjectComponent;
    Renderer rendererComponent;
    Outline outlineComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickupableObjectComponent = GetComponent<PickupableObject>();
        rendererComponent = GetComponent<Renderer>();
        if(pickupableObjectComponent == null) throw new System.Exception("Object is not a pickupableObject:" + gameObject);

        changeObjectTo(startingType);
    }

    // Update is called once per frame
    void Update()
    {
        if (pickupableObjectComponent != null && pickupableObjectComponent.isPickedUp)
        {
            if (Input.GetKeyDown(obj1Key)) changeObjectTo(ObjectShape.Cube);
            if (Input.GetKeyDown(obj2Key)) changeObjectTo(ObjectShape.Sphere);
            if (Input.GetKeyDown(obj3Key)) changeObjectTo(ObjectShape.Tetrahedron);
        }
    }

    void changeObjectTo(ObjectShape type)
    {
        switch (type)
        {
            case ObjectShape.Core:
                GetComponent<MeshFilter>().mesh = coreMesh;
                Destroy(GetComponent<Collider>());
                gameObject.AddComponent<BoxCollider>();
                rendererComponent.material = materials[0];
                break;
            case ObjectShape.Cube:
                GetComponent<MeshFilter>().mesh = cubeMesh;
                Destroy(GetComponent<Collider>());
                gameObject.AddComponent<BoxCollider>();
                rendererComponent.material = materials[1];
                break;
            case ObjectShape.Sphere:
                GetComponent<MeshFilter>().mesh = sphereMesh;
                Destroy(GetComponent<Collider>());
                gameObject.AddComponent<SphereCollider>();
                rendererComponent.material = materials[2];
                break;
            case ObjectShape.Tetrahedron:
                GetComponent<MeshFilter>().mesh = tetrahedronMesh;
                Destroy(GetComponent<Collider>());
                MeshCollider col = gameObject.AddComponent<MeshCollider>();
                col.sharedMesh = tetrahedronMesh;
                col.convex = true;
                col.enabled = true;
                rendererComponent.material = materials[3];
                break;
        }

        currentType = type;
    }
}

//enum for object Types
public enum ObjectShape
{
    Core = 0,
    Cube = 1,
    Sphere = 2,
    Tetrahedron = 3
}
