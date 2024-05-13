using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMain : MonoBehaviour {

    [SerializeField] Camera mainCamera;
    bool isDestory;
    GameContext ctx;

    void Start() {
        ctx = new GameContext();
        Load();
        ctx.Inject(mainCamera);
        ctx.poolService.Init(() => GameFactory.Role_Create(ctx));
        GameBusiness_Normal.Enter(ctx);
    }

    private void Load() {
        ctx.asset.LoadAll();
    }

    void Update() {

        float dt = Time.deltaTime;
        ctx.input.Process(ctx.camreEntity.camera.transform.forward, ctx.camreEntity.camera.transform.right);

        var status = ctx.fsm.status;
        if (status == GameStatus.Normal) {
            GameBusiness_Normal.Tick(ctx, dt);
        }


    }

    public void Unload() {
        ctx.asset.Unload();
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
