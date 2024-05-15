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

    // Componet
    public GunComponent gunCom;

    // faceDir;
    public float rotationSpeed;

    public RoleEntity() {
        gunCom = new GunComponent();
    }

    public void Ctor(Animator anim) {
        this.anim = anim;
        rotationSpeed = 600;
    }

    public void Move(Vector3 moveAxis, float dt, float cameraRotationY) {

        var velocity = rb.velocity;
        velocity = moveAxis.normalized * moveSpeed;
        rb.velocity = velocity;

        if (moveAxis == Vector3.zero) {
            return;
        }
        // Update Forward
        if (moveAxis == Vector3.zero) {
            return;
        }

        if (GetForward() == moveAxis) {
            return;
        }
        float angle = Vector3.Angle(moveAxis.normalized, GetForward().normalized);
        if (angle < 1) {
            return;
        }
        Vector3 cross = Vector3.Cross(moveAxis.normalized, GetForward().normalized);
        if (cross.y > 0) {
            transform.Rotate(Vector3.up, -rotationSpeed * dt);
        } else {
            // angle = 360 - angle;
            // Debug.Log("IN"+rotationSpeed*dt);
            transform.Rotate(Vector3.up, rotationSpeed * dt);
        }
    }

    public float GetRotationY() {
        return transform.rotation.y;
    }

    public void SetForward(Vector3 forward) {
        transform.forward = forward;
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