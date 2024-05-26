using UnityEngine;
using Cinemachine;
using System;

public class CameraEntity {
    public CinemachineFreeLook normalCamera;
    public CinemachineFreeLook shootLookCamera;
    public CinemachineFreeLook fpsLookCamera;
    public CinemachineFreeLook currentCam;
    public Camera currentCamera; // 目前没用到。用brain切换相机没成功
    public CameraType cameraType;
    public Vector2 normalCameraAxisSpeed;
    public Vector2 shootCameraAxisSpeed;
    public Vector2 fpsLookCameraAxisSpeed;
    public CameraEntity() {
        normalCameraAxisSpeed = new Vector2(300, 2);
        shootCameraAxisSpeed = new Vector2(300, 2);
        fpsLookCameraAxisSpeed = new Vector2(300, 2);
    }

    public void Ctor() {
    }

    public void Inject(Camera currentCamera, CinemachineFreeLook normalCamera, CinemachineFreeLook shootCamera, CinemachineFreeLook fpsLookCamera) {
        this.currentCamera = currentCamera;
        this.normalCamera = normalCamera;
        this.shootLookCamera = shootCamera;
        this.fpsLookCamera = fpsLookCamera;
    }

    public void EnterShoot() {
        cameraType = CameraType.Shoot;
        if (currentCam) {
            // 切换相机要用上次的鼠标偏移位置，来保持相机的旋转角度不变
            shootLookCamera.m_YAxis = currentCam.m_YAxis;
            shootLookCamera.m_XAxis = currentCam.m_XAxis;
            currentCam.gameObject.SetActive(false);
        }
        shootLookCamera.gameObject.SetActive(true);

        currentCam = shootLookCamera;
    }

    public void EnterNormal() {
        cameraType = CameraType.Normal;
        if (currentCam) {
            normalCamera.m_YAxis = currentCam.m_YAxis;
            normalCamera.m_XAxis = currentCam.m_XAxis;
            currentCam.gameObject.SetActive(false);
        }
        normalCamera.gameObject.SetActive(true);

        currentCam = normalCamera;
    }

    public void EnterFPS() {
        cameraType = CameraType.Fps;
        if (currentCam) {
            fpsLookCamera.m_YAxis = currentCam.m_YAxis;
            fpsLookCamera.m_XAxis = currentCam.m_XAxis;
            currentCam.gameObject.SetActive(false);
        }
        fpsLookCamera.gameObject.SetActive(true);
        currentCam = fpsLookCamera;
    }

    public Vector3 GetPos() {
        return currentCam.transform.position;
    }

    public void SetLookAt(Transform target) {
        currentCam.LookAt = target;
    }

    public void SetFollow(Transform target) {
        currentCam.Follow = target;
    }

    public Vector2 GetCameraAxisSpeed() {
        if (cameraType == CameraType.Normal) {
            return normalCameraAxisSpeed;
        } else if (cameraType == CameraType.Shoot) {
            return shootCameraAxisSpeed;
        } else if (cameraType == CameraType.Fps) {
            return fpsLookCameraAxisSpeed;
        } else {
            return default;
        }
    }

    public void CloseRotation() {
        currentCam.m_XAxis.m_MaxSpeed = 0;
        currentCam.m_YAxis.m_MaxSpeed = 0;
    }

    public void OpenRotation() {
        var axisSpeed = GetCameraAxisSpeed();
        currentCam.m_XAxis.m_MaxSpeed = axisSpeed.x;
        currentCam.m_YAxis.m_MaxSpeed = axisSpeed.y;
    }

    internal Vector3 GetForward() {
        return currentCamera.transform.forward;
    }
}