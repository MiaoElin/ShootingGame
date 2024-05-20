using UnityEngine;

public class GameFsmComponent {

    public GameStatus status;

    public bool isEnterNormal;
    public bool isEnterOpenBag;

    public void EnterNormal() {
        status = GameStatus.Normal;
        isEnterNormal = true;
    }

    public void EnterOpenBag() {
        status = GameStatus.OpenBag;
        isEnterOpenBag = true;
    }
}