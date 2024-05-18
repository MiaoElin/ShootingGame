using System;
using System.Collections;
using UnityEngine;
using Cinemachine;

public class ClientMain : MonoBehaviour {

    [SerializeField] CinemachineFreeLook normalCamera;
    [SerializeField] CinemachineFreeLook shootCamera;
    [SerializeField] Camera currentCamera;
    [SerializeField] Canvas screenCanvas;
    bool isDestory;
    GameContext ctx;

    void Start() {

        // 锁定鼠标
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ctx = new GameContext();
        Load();
        ctx.Inject(normalCamera, shootCamera, currentCamera, screenCanvas);
        ctx.poolService.Init(() => GameFactory.Role_Create(ctx));
        GameBusiness_Normal.Enter(ctx);
    }

    private void Load() {
        ctx.asset.LoadAll();
        ctx.soundCore.LoadAll();
    }

    void Update() {

        float dt = Time.deltaTime;
        ctx.input.Process(currentCamera.transform.forward, currentCamera.transform.right);

        var status = ctx.fsm.status;
        if (status == GameStatus.Normal) {
            GameBusiness_Normal.Tick(ctx, dt);
        }


    }

    public void Unload() {
        ctx.asset.Unload();
        ctx.soundCore.Unload();
    }

    void OnApplicationQuit() {
        TearDown();
    }

    void OnDestory() {
        TearDown();
    }

    void TearDown() {
        if (isDestory) {
            return;
        }
        Unload();
        isDestory = true;
    }
}
