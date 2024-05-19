using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.5f;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
        this.enabled = false; // Disable the script at the start
    }

    public void EnableCameraFollow() // Public method to enable the script
    {
        this.enabled = true;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}