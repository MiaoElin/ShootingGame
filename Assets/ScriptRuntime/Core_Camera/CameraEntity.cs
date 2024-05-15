using UnityEngine;

public class CameraEntity {

    public Camera camera;
    public Vector3 offset;
    public float distance;

    public CameraEntity() {
        //暂时的，是相机与角色的距离；
    }

    public void Ctor() {
        offset = camera.transform.position;
        distance = Vector3.Distance(camera.transform.position, Vector3.zero);
    }

    public Vector3 GetPos() {
        return camera.transform.position;
    }

    public void LookAt(Vector3 target) {
        camera.transform.forward = target - camera.transform.position;
    }

    public void Follow(Vector2 mouseAxis, float dt) {
        camera.transform.Rotate(-mouseAxis.y * 1000 * dt, 0, 0);

        // mouseAxis = mouseAxis * dt;
        // mouseAxis *= 1000;
        // mouseAxis.y = -mouseAxis.y;
        // var rotation = camera.transform.eulerAngles;
        // if (rotation.x > 270 && rotation.x < 360) {
        //     rotation.x = rotation.x - 360;
        // }
        // Vector3 dir = (camera.transform.position - role.GetLastPos()).normalized;
        // var angleX = rotation.x + mouseAxis.y;
        // if (angleX > -26 && angleX < 60) {
        //     var rotX = Quaternion.AngleAxis(mouseAxis.y, camera.transform.right);
        //     dir = rotX * dir;
        // }
        // var roty = Quaternion.AngleAxis(mouseAxis.x, Vector3.up);
        // dir = roty * dir;
        // dir *= distance;
        // offset = dir;
        // camera.transform.position = role.GetPos() + offset; // 相机的位置要根据角色现在的位置！
        // LookAt(role.GetLastPos() + Vector3.up * 3);
    }
}