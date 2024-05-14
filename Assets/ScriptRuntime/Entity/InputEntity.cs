using UnityEngine;

public class InputEntity {

    public Vector3 moveAxis;
    public Vector2 mouseAxis;

    public void Process(Vector3 forward, Vector3 right) {
        moveAxis = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) {
            moveAxis.z = 1;
        } else if (Input.GetKey(KeyCode.S)) {
            moveAxis.z = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            moveAxis.x = -1;
        } else if (Input.GetKey(KeyCode.D)) {
            moveAxis.x = 1;
        }
        forward.y = 0;
        right.y = 0;
        moveAxis = moveAxis.z * forward.normalized + moveAxis.x * right.normalized;
        moveAxis = moveAxis.normalized;
        // moveAxis = cameraQut * moveAxis;
        // moveAxis.y = 0;

        mouseAxis = Vector2.zero;
        if (Input.GetMouseButton(0)) {
            mouseAxis.x = Input.GetAxis("Mouse X");
            mouseAxis.y = Input.GetAxis("Mouse Y");
        }
    }
}