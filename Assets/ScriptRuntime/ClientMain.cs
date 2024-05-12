using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMain : MonoBehaviour {

    GameContext ctx = new GameContext();
    
    void Start() {

    }

    void Update() {
        ctx.input.Process();
    }
}
