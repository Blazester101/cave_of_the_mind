//using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class ShiftableObject : MonoBehaviour
{
    public static UnityEvent objectChangedEvent = new UnityEvent();
    public static KeyCode obj1Key = KeyCode.Alpha1;
    public static KeyCode obj2Key = KeyCode.Alpha2;
    public static KeyCode obj3Key = KeyCode.Alpha3;

    public ObjectShape key1ObjectType = ObjectShape.Cube;
    public ObjectShape key2ObjectType = ObjectShape.Sphere;
    public ObjectShape key3ObjectType = ObjectShape.Tetrahedron;

    public Mesh coreMesh;
    public Mesh cubeMesh;
    public Mesh sphereMesh;
    public Mesh tetrahedronMesh;
    public Mesh coinMesh;
    public Mesh sevenMesh;
    public Mesh cherriesMesh;
    public Mesh diamondMesh;

    public ObjectShape startingType;
    public ObjectShape currentType;

    public Material[] materials;

    PickupableObject pickupableObjectComponent;
    Renderer rendererComponent;
    Outline outlineComponent;

    //To play particle system animation.

    //Reference to an existing particle prefab
    [SerializeField] private ParticleSystem particleSystem;

    //References each particle system instance spawned into a scene
    private ParticleSystem particleSystemInstance;

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
            if (Input.GetKeyDown(obj1Key)) changeObjectTo(key1ObjectType);
            if (Input.GetKeyDown(obj2Key)) changeObjectTo(key2ObjectType);
            if (Input.GetKeyDown(obj3Key)) changeObjectTo(key3ObjectType);
        }
    }

    void changeObjectTo(ObjectShape type)
    {
        bool isValidShape = true;
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
                {
                    GetComponent<MeshFilter>().mesh = tetrahedronMesh;
                    Destroy(GetComponent<Collider>());
                    MeshCollider col = gameObject.AddComponent<MeshCollider>();
                    col.sharedMesh = tetrahedronMesh;
                    col.convex = true;
                    col.enabled = true;
                    rendererComponent.material = materials[3];
                }
                break;
            case ObjectShape.Coin:
                {
                    GetComponent<MeshFilter>().mesh = coinMesh;
                    Destroy(GetComponent<Collider>());
                    MeshCollider col = gameObject.AddComponent<MeshCollider>();
                    col.sharedMesh = coinMesh;
                    col.convex = true;
                    col.enabled = true;
                    rendererComponent.material = materials[4];
                }
                break;
            case ObjectShape.Seven:
                {
                    GetComponent<MeshFilter>().mesh = sevenMesh;
                    Destroy(GetComponent<Collider>());
                    MeshCollider col = gameObject.AddComponent<MeshCollider>();
                    col.sharedMesh = sevenMesh;
                    col.convex = true;
                    col.enabled = true;
                    rendererComponent.material = materials[5];
                }
                break;
            case ObjectShape.Cherries:
                {
                    GetComponent<MeshFilter>().mesh = cherriesMesh;
                    Destroy(GetComponent<Collider>());
                    MeshCollider col = gameObject.AddComponent<MeshCollider>();
                    col.sharedMesh = cherriesMesh;
                    col.convex = true;
                    col.enabled = true;
                    rendererComponent.material = materials[6];
                }
                break;
            case ObjectShape.Diamond:
                {
                    GetComponent<MeshFilter>().mesh = diamondMesh;
                    Destroy(GetComponent<Collider>());
                    MeshCollider col = gameObject.AddComponent<MeshCollider>();
                    col.sharedMesh = diamondMesh;
                    col.convex = true;
                    col.enabled = true;
                    rendererComponent.material = materials[7];
                }
                break;
            default:
                Debug.LogError("Invalid object type: " + type);
                isValidShape = false;
                break;
        }

        if (isValidShape) 
            currentType = type;

        SpawnParticleEffect(); //TODO: make this only play if the new object type is different than the previous type
    }

    private void SpawnParticleEffect() {
        particleSystemInstance = Instantiate(particleSystem, (transform.position + new Vector3(0, -3, 0)), Quaternion.identity);
    }
}

//enum for object Types
public enum ObjectShape
{
    Core = 0,
    Cube = 1,
    Sphere = 2,
    Tetrahedron = 3,
    Coin = 4,
    Seven = 5,
    Cherries = 6,
    Diamond = 7
}




