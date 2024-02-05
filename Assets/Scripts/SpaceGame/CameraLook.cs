using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            transform.LookAt(playerTransform);
        }
    }
}
