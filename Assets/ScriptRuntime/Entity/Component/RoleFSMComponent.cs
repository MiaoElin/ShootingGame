using UnityEngine;

public class RoleFSMComponent {
    public RoleStatus status;
    public bool isNormal;

    public bool isShoot;

    public bool isFPS;

    public void EnterNormal() {
        status = RoleStatus.Normal;
        isNormal = true;
    }

    public void EnterShoot() {
        status = RoleStatus.Shoot;
        isShoot = true;
    }

    public void EnterFPS() {
        status = RoleStatus.FPS;
        isFPS = true;
    }
}