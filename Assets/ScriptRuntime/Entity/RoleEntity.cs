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
    public bool isEnterGround;

    [SerializeField] Animator anim;
    public GameObject body;
    public Transform lookAtPoint;
    public Transform orientation;

    public bool isShootReady;

    // input
    public bool isJumpKeyDown;
    public bool isPickKeyDown;

    // Componet
    public GunComponent gunCom;
    public StuffComponent stuffCom;
    public EquipComponent equipCom;

    // faceDir;
    public float rotationSpeed;

    public RoleEntity() {
        gunCom = new GunComponent();
        roleFSMComponent = new RoleFSMComponent();
    }

    public void Ctor(Animator anim) {
        this.anim = anim;
        rotationSpeed = 10;
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
            // 注意这里转的是body，与准心分开的
            body.transform.forward = Vector3.Lerp(body.transform.forward, moveAxis.normalized, dt * rotationSpeed);
        }
    }

    public void SetForward_Shoot(Vector3 cameraPos) {
        // 准心和body的forward是一起变的，所以直接转Transform（XX),不可以,进入shoot前，如果body的forward初始值要和orientation一样才行，
        // 如果初始值不一样，一起转，无法让orientation和body的forward都等于相机的forward；

        // 旋转orientation的forward
        var viewDir = lookAtPoint.position - cameraPos;
        viewDir.y = 0;
        orientation.forward = viewDir;
        // 旋转body的forward
        body.transform.forward = Vector3.Lerp(body.transform.forward, viewDir.normalized, 0.01f * rotationSpeed);
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


    public Vector3 Pos() {
        return transform.position;
    }


    public void Anim_Run() {
        anim.SetFloat("F_MoveSpeed", rb.velocity.magnitude);
    }

    public void Anim_Jump() {
        anim.SetTrigger("T_Jump");
    }


}