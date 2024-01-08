using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPlatform : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float forceMagnitude = 10f;

    void Update()
    {
        // Get the current rotation
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Only modify the Z-axis rotation
        currentRotation.z += rotationSpeed * Time.deltaTime;

        // Apply the modified rotation
        transform.rotation = Quaternion.Euler(currentRotation);
    }
}
