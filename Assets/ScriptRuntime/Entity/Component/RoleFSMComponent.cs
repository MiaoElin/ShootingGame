using UnityEngine;

public class RoleFSMComponent {
    public RoleStatus status;
    public bool isNormal;

    public bool isShoot;

    public void EnterNormal() {
        status = RoleStatus.Normal;
        isNormal = true;
    }

    public void EnterShoot() {
        status = RoleStatus.Shoot;
        isShoot = true;
    }
}