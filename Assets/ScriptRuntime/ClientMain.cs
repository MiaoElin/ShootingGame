using System;
using System.Collections;
using UnityEngine;
using Cinemachine;

public class ClientMain : MonoBehaviour {

    [SerializeField] CinemachineFreeLook mainCamera;
    [SerializeField] Camera cameraR;
    [SerializeField] Canvas screenCanvas;
    bool isDestory;
    GameContext ctx;

    void Start() {
        ctx = new GameContext();
        Load();
        ctx.Inject(mainCamera, cameraR, screenCanvas);
        ctx.poolService.Init(() => GameFactory.Role_Create(ctx));
        GameBusiness_Normal.Enter(ctx);
    }

    private void Load() {
        ctx.asset.LoadAll();
        ctx.soundCore.LoadAll();
    }

    void Update() {

        float dt = Time.deltaTime;
        ctx.input.Process(cameraR.transform.rotation);

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
