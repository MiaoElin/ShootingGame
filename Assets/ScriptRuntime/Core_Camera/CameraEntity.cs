using UnityEngine;
using Cinemachine;

public class CameraEntity {
    public CinemachineFreeLook normalCamera;
    public CinemachineFreeLook shootLookCamera;
    public CinemachineFreeLook currentCam;
    public Camera currentCamera; // 目前没用到。用brain切换相机没成功

    public CameraEntity() {
    }

    public void Inject(Camera currentCamera, CinemachineFreeLook normalCamera, CinemachineFreeLook shootCamera) {
        this.currentCamera = currentCamera;
        this.normalCamera = normalCamera;
        this.shootLookCamera = shootCamera;
    }

    public void EnterShoot() {
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
        if (currentCam) {
            normalCamera.m_YAxis = currentCam.m_YAxis;
            normalCamera.m_XAxis = currentCam.m_XAxis;
            currentCam.gameObject.SetActive(false);
        }
        normalCamera.gameObject.SetActive(true);

        currentCam = normalCamera;

    }

    public void Ctor() {
    }

    public Vector3 GetPos() {
        return currentCamera.transform.position;
    }

    public void SetLookAt(Transform target) {
        currentCam.LookAt = target;
    }

    public void SetFollow(Transform target) {
        currentCam.Follow = target;
    }
}