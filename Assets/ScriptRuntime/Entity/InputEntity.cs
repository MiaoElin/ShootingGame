using UnityEngine;

public class InputEntity {

    public Vector3 moveAxis;

    public void Process() {
        moveAxis = Vector2.zero;
        if (Input.GetButton("Vertical")) {
            moveAxis.z = Input.GetAxis("Vertical");
            // }else if(Input.GetKeyDown(KeyCode.S)){
            //     moveAxis.y=-1;
        }
        if (Input.GetKey(KeyCode.A)) {
            moveAxis.x = -1;
        } else if (Input.GetKey(KeyCode.D)) {
            moveAxis.x = 1;
        }
    }
}