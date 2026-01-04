using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetA;
    public Transform targetB;
    public float smoothSpeed;
    public Vector3 offset;

    void LateUpdate()
    {
        if (targetA != null && targetB != null)
        {
            var midpoint = (targetA.position + targetB.position) / 2f;
            
            var desiredPosition = midpoint + offset;
            
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}