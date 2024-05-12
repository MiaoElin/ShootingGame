using UnityEngine;

public class InputEntity {

    public Vector2 moveAxis;

    public void Process() {
        moveAxis = Vector2.zero;
        if (Input.GetButtonDown("Horizontal")) {
            moveAxis.x = Input.GetAxis("Horizontal");
            // }else if(Input.GetKeyDown(KeyCode.S)){
            //     moveAxis.y=-1;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            moveAxis.x = -1;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            moveAxis.x = 1;
        }
    }
}