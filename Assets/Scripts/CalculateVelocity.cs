using UnityEngine;

public class CalculateVelocity : MonoBehaviour
{
    private Vector3 lastPosition;
    public float speed = 0;

    private void Start()
    {
        lastPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Abs(Vector3.Magnitude(lastPosition - transform.position))/Time.deltaTime;
        lastPosition = transform.position;
    }
}
