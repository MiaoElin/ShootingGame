using UnityEngine;
using Cinemachine;

public class CameraEntity {
    public CinemachineFreeLook normalCamera;
    public CinemachineFreeLook shootLookCamera;
    public CinemachineFreeLook current;
    public Camera currentCamera; // 目前没用到。用brain切换相机没成功

    public CameraEntity() {
    }

    public void Inject(Camera currentCamera, CinemachineFreeLook normalCamera, CinemachineFreeLook shootCamera) {
        this.currentCamera = currentCamera;
        this.normalCamera = normalCamera;
        this.shootLookCamera = shootCamera;
    }

    public void EnterShoot() {
        shootLookCamera.m_YAxis = normalCamera.m_YAxis;
        shootLookCamera.m_XAxis = normalCamera.m_XAxis;
        current = shootLookCamera;
        normalCamera.gameObject.SetActive(false);
        shootLookCamera.gameObject.SetActive(true);
    }

    public void EnterNormal() {
        normalCamera.m_YAxis = shootLookCamera.m_YAxis;
        normalCamera.m_XAxis = shootLookCamera.m_XAxis;
        current = normalCamera;
        shootLookCamera.gameObject.SetActive(false);
        normalCamera.gameObject.SetActive(true);
    }

    public void Ctor() {
    }

    public Vector3 GetPos() {
        return currentCamera.transform.position;
    }

    public void SetLookAt(Transform target) {
        current.LookAt = target;
    }

    public void SetFollow(Transform target) {
        current.Follow = target;
    }
}