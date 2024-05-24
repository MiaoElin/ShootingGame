using System;
using UnityEngine;

public class BulletEntity : MonoBehaviour {

    public int typeID;
    public int id;
    public BulletMoveType bulletMoveType;
    public int damage;
    public float moveSpeed;
    public Transform modTransform;
    [SerializeField] Rigidbody rb;
    public Vector3 dir;

    public void Ctor(GameObject mod) {
        GameObject.Instantiate(mod, modTransform);
    }

    public void Move(Vector3 dir) {
        if (dir == Vector3.zero) {
            return;
        }
        var velocity = rb.velocity;
        velocity += dir.normalized * moveSpeed;
        rb.velocity = velocity;
        SetForward(dir);
    }

    public void MoveTo_Target(Vector3 target, float dt) {
        Vector2 dir = target - transform.position;
        if (Vector3.SqrMagnitude(dir) < moveSpeed * dt) {
            return;
        }
        Move(dir);
        SetForward(dir);
    }

    public void SetForward(Vector3 dir) {
        transform.forward = dir;
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    internal void SetPos(Vector3 pos) {
        transform.position = pos;
    }

    internal Vector3 Pos() {
        return transform.position;
    }
}