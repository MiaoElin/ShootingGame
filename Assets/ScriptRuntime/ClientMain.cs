using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMain : MonoBehaviour {
    bool isDestory;
    GameContext ctx = new GameContext();

    void Start() {
        Load();
        GameBusiness_Normal.Enter(ctx);
    }

    private void Load() {
        ctx.asset.LoadAll();
    }

    void Update() {

        float dt = Time.deltaTime;
        

        ctx.input.Process();
        GameBusiness_Normal.Tick(ctx, dt);


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
