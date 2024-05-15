using UnityEngine;

public class RoleEntity : MonoBehaviour {

    public int typeId;
    public int id;
    public int hp;
    public int hpMax;
    public float moveSpeed;
    public MoveType moveType;
    public Vector3 lastPos;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;
    public GameObject body;
    public GameObject cameraT;

    // Componet
    public GunComponent gunCom;

    // faceDir;
    public float rotationSpeed;
    public Vector3 startForward;
    public Vector3 endForward;
    public Vector3 oldForward;
    public float time;
    public float duration;

    public RoleEntity() {
        gunCom = new GunComponent();
    }

    public void Ctor(Animator anim) {
        this.anim = anim;
        rotationSpeed = 100;
        duration = 0.25f;
    }

    public void Move(Vector3 moveAxis, float dt) {

        var velocity = rb.velocity;
        velocity = moveAxis.normalized * moveSpeed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

        if (moveAxis == Vector3.zero) {
            return;
        }
        // Update Forward
        // var bodyAngle = body.transform.eulerAngles;
        // var cameraAngle = cameraT.transform.eulerAngles;
        // if (bodyAngle.y != cameraAngle.y) {
        //     bodyAngle.y = cameraAngle.y;
        //     body.transform.eulerAngles = bodyAngle;
        // }
        SetForward(moveAxis);

        // if (moveAxis == Vector3.zero) {
        //     return;
        // }

        // // Update Forward 方法1
        Vector3 newForward = new Vector3(moveAxis.x, 0, moveAxis.z);
        if (newForward != oldForward) {
            startForward = oldForward;
            if (startForward == Vector3.zero) {
                startForward = transform.forward;
            }
            endForward = newForward;
            oldForward = newForward;
            time = 0;
        }

        if (time <= duration) {
            time += dt;
            var quatStar = Quaternion.LookRotation(startForward);
            var quatEnd = Quaternion.LookRotation(endForward);
            body.transform.rotation = Quaternion.Lerp(quatStar, quatEnd, time / duration);
        }
    }

    public void SetRotation(Vector2 mouseAxis, float dt) {
        mouseAxis *= 1000;
        mouseAxis.y = -mouseAxis.y;
        // transform.Rotate(0, mouseAxis.x, 0);
        // cameraT.transform.Rotate(-mouseAxis.y * 300f * dt, 0, 0);
        Quaternion qutY = Quaternion.AngleAxis(mouseAxis.x * dt, Vector3.up);
        Quaternion qutX = Quaternion.AngleAxis(mouseAxis.y * dt, cameraT.transform.right);
        cameraT.transform.forward = qutY * cameraT.transform.forward;
        cameraT.transform.forward = qutX * cameraT.transform.forward;
    }

    public float GetRotationY() {
        return transform.rotation.y;
    }

    public void SetForward(Vector3 forward) {
        body.transform.forward = forward;
    }

    public Vector3 GetForward() {
        return transform.forward;
    }

    public void SetPos(Vector3 pos) {
        transform.position = pos;
    }

    public void SetLastPos(Vector3 pos) {
        this.lastPos = pos;
    }

    public Vector3 GetPos() {
        return transform.position;
    }

    public Vector3 GetLastPos() {
        return lastPos;
    }

    public void Anim_Run() {
        anim.SetFloat("F_MoveSpeed", rb.velocity.magnitude);
    }


}