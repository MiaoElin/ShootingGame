using UnityEngine;
using Cinemachine;

public class CameraEntity {
    public CinemachineFreeLook normalCamera;
    public CinemachineFreeLook shootLookCamera;

    public CinemachineFreeLook currentCamera;

    public CameraEntity() {
        //暂时的，是相机与角色的距离；
    }

    public void Inject(CinemachineFreeLook normalCamera, CinemachineFreeLook shootCamera) {
        this.normalCamera = normalCamera;
        this.shootLookCamera = shootCamera;
    }

    public void EnterShoot() {
        normalCamera.gameObject.SetActive(false);
        currentCamera = shootLookCamera;
    }

    public void EnterNormal() {
        shootLookCamera.gameObject.SetActive(false);
        currentCamera = normalCamera;
    }

    public void Ctor() {
    }

    public Vector3 GetPos() {
        return currentCamera.transform.position;
    }

    public void SetLookAt(Transform target) {
        currentCamera.LookAt = target;
    }

    public void SetFollow(Transform target) {
        currentCamera.Follow = target;
    }
}