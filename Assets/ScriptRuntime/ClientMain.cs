using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMain : MonoBehaviour {
    bool isDestory;
    GameContext ctx = new GameContext();

    void Start() {
        Load();
    }

    private void Load() {
        ctx.asset.LoadAll();
    }

    void Update() {
        ctx.input.Process();
        


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
