using System;
using UnityEngine;


public class BulletEntity : MonoBehaviour {
    public int typeID;
    public int id;
    public bool isDead;
    public Ally ally;
    public float maxFlyTimer;
    public float maxFlyDistance;
    public BulletMoveType bulletMoveType;
    public int damage;
    public Vector3 halfExtents;
    public float moveSpeed;
    public Transform modTransform;
    [SerializeField] Rigidbody rb;
    public Vector3 dir;

    public void Ctor(GameObject mod, float moveSpeed,float maxFlyDistance) {
        GameObject.Instantiate(mod, modTransform);
        this.moveSpeed = moveSpeed;
        this.maxFlyDistance=maxFlyDistance;
        maxFlyTimer = (maxFlyDistance / moveSpeed);
    }

    public void Move(Vector3 dir, float dt) {
        if (maxFlyTimer <= 0) {
            isDead = true;
            return;
        }
        maxFlyTimer -= dt;
        var velocity = rb.velocity;
        velocity = dir.normalized * moveSpeed;
        rb.velocity = velocity;
        SetForward(dir);
    }

    public void MoveTo_Target(Vector3 target, float dt) {
        Vector2 dir = target - transform.position;
        if (Vector3.SqrMagnitude(dir) < moveSpeed * dt) {
            return;
        }
        Move(dir, dt);
        SetForward(dir);
    }

    public void SetForward(Vector3 dir) {
        transform.forward = dir;
    }

    public Vector3 GetForward() {
        return transform.forward;
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