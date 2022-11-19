using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera followCam;
    [SerializeField] private CinemachineFreeLook freeLookCam;
    [SerializeField] private float mouseLookSensitivity = 1f;
    
    private CinemachineComposer aim;

    private void Awake()
    {
        aim = followCam.GetCinemachineComponent<CinemachineComposer>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            freeLookCam.Priority = 100;
            freeLookCam.m_RecenterToTargetHeading.m_enabled = false;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            freeLookCam.Priority = 0;
            freeLookCam.m_RecenterToTargetHeading.m_enabled = true;
        }

        if (!Input.GetMouseButton(1))
        {
            var vertical = Input.GetAxis("Mouse Y") * mouseLookSensitivity;
            aim.m_TrackedObjectOffset.y += vertical;
            aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, -10f, 10f);
        }
    }
}
