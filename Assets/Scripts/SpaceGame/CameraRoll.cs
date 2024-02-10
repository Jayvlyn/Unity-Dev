using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoll : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private GameObject target;

    // Update is called once per frame
    void Update()
    {
        cam.m_Lens.Dutch = 2 * Mathf.Rad2Deg * target.transform.rotation.z;
    }
}
