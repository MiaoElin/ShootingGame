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
        rotationSpeed = 7;
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
        if (moveAxis != Vector3.zero) {
            body.transform.forward = Vector3.Lerp(body.transform.forward, moveAxis.normalized, dt * rotationSpeed);
        }
        // // Update Forward 方法1
        // Vector3 newForward = new Vector3(moveAxis.x, 0, moveAxis.z);
        // if (newForward != oldForward) {
        //     startForward = oldForward;
        //     if (startForward == Vector3.zero) {
        //         startForward = transform.forward;
        //     }
        //     endForward = newForward;
        //     oldForward = newForward;
        //     time = 0;
        // }
        // Debug.Log(moveAxis);
        // if (time <= duration) {
        //     time += dt;
        //     var quatStar = Quaternion.LookRotation(startForward);
        //     var quatEnd = Quaternion.LookRotation(endForward);
        //     body.transform.rotation = Quaternion.Lerp(quatStar, quatEnd, time / duration);
        // }
    }

    public void SetRotation(float angle) {
        var rotation = transform.eulerAngles;
        rotation.y = angle;
        transform.eulerAngles = rotation;
    }

    public void Jump() {

    }

    public void Falling() {

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

    public void Anim_Jump() {
        anim.SetTrigger("T_Jump");
    }


}