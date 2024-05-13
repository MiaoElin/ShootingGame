using UnityEngine;

public class InputEntity {

    public Vector3 moveAxis;
    public Vector2 mouseAxis;

    public void Process(Vector3 forward, Vector3 right) {
        moveAxis = Vector2.zero;
        if (Input.GetButton("Vertical")) {
            moveAxis.z = Input.GetAxis("Vertical");
        }
        if (Input.GetKey(KeyCode.A)) {
            moveAxis.x = -1;
        } else if (Input.GetKey(KeyCode.D)) {
            moveAxis.x = 1;
        }
        forward.y = 0;
        right.y = 0;
        moveAxis = moveAxis.z * forward.normalized + moveAxis.x * right.normalized;

        mouseAxis = Vector2.zero;
        if (Input.GetMouseButton(0)) {
            mouseAxis.x = Input.GetAxis("Mouse X");
            mouseAxis.y = Input.GetAxis("Mouse Y");
        }
    }
}