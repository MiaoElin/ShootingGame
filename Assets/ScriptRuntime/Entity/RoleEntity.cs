using UnityEngine;

public class RoleEntity : MonoBehaviour {

    public int typeId;
    public int id;
    public int hp;
    public int hpMax;
    public RoleFSMComponent roleFSMComponent;
    public float moveSpeed;
    public MoveType moveType;

    [SerializeField] Rigidbody rb;
    public float gravity;
    public float jumpingForce;
    public bool isInGround;

    [SerializeField] Animator anim;
    public GameObject body;
    public Transform lookAtPoint;
    public Transform orientation;

    public bool isShootReady;

    // input
    public bool isJumpKeyDown;

    // Componet
    public GunComponent gunCom;

    // faceDir;
    public float rotationSpeed;

    public RoleEntity() {
        gunCom = new GunComponent();
        roleFSMComponent = new RoleFSMComponent();
    }

    public void Ctor(Animator anim) {
        this.anim = anim;
        rotationSpeed = 7;
    }

    public void Move(Vector3 moveAxis, float dt) {

        var velocity = rb.velocity;
        velocity = moveAxis.normalized * moveSpeed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

        if (moveAxis == Vector3.zero) {
            return;
        }
    }

    public Vector3 Velocity() {
        return rb.velocity;
    }

    public void SetForward_Normal(Vector3 moveAxis, Vector3 cameraPos, float dt) {
        // Update Orientation Forward
        var viewDir = lookAtPoint.position - cameraPos;
        viewDir.y = 0;
        orientation.forward = viewDir;
        // Update RoleEntity Forward
        if (moveAxis != Vector3.zero) {
            transform.forward = Vector3.Lerp(transform.forward, moveAxis.normalized, dt * rotationSpeed);
        }
    }

    public void SetForward_Shoot(Vector3 cameraPos) {
        var viewDir = lookAtPoint.position - cameraPos;
        viewDir.y = 0;
        transform.forward = viewDir;
    }

    public bool IsJump() {
        if (isInGround && isJumpKeyDown) {
            isInGround = false;
            var velocity = rb.velocity;
            velocity.y = jumpingForce;
            rb.velocity = velocity;
            return true;
        }
        return false;
    }

    public void Falling(float dt) {
        var velocity = rb.velocity;
        velocity.y -= gravity * dt;
        rb.velocity = velocity;
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


    public Vector3 GetPos() {
        return transform.position;
    }


    public void Anim_Run() {
        anim.SetFloat("F_MoveSpeed", rb.velocity.magnitude);
    }

    public void Anim_Jump() {
        anim.SetTrigger("T_Jump");
    }


}