using System;
using System.Collections;
using UnityEngine;
using Cinemachine;

public class ClientMain : MonoBehaviour {

    [SerializeField] CinemachineFreeLook normalCamera;
    [SerializeField] CinemachineFreeLook shootCamera;
    [SerializeField] Camera currentCamera;
    [SerializeField] Canvas screenCanvas;
    [SerializeField] Canvas worldCanvas;
    [SerializeField] Terrain terrain;
    bool isDestory;
    GameContext ctx;

    void Start() {

        // var a = terrain.terrainData.detailPrototypes;
        // foreach (var pro in a) {
        //     var meshR = pro.prototype.GetComponent<MeshRenderer>();
        //     meshR.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        // }

        // 锁定鼠标
        Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;

        ctx = new GameContext();
        Load();
        ctx.Inject(normalCamera, shootCamera, currentCamera, screenCanvas, worldCanvas);
        ctx.poolService.Init(
        () => GameFactory.Role_Create(ctx),
        () => GameFactory.Loot_Create(ctx),
        () => GameFactory.Prop_Create(ctx),
        () => GameFactory.Bullet_Create(ctx));
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
        } else if (status == GameStatus.OpenBag) {
            GameBusiness_OpenBag.Tick(ctx);
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
