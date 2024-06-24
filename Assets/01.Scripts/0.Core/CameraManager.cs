using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    [SerializeField] private CinemachineVirtualCamera _vCam;

    public void SetTarget(Transform transform)
    {
        _vCam.Follow = transform;
    }
}
