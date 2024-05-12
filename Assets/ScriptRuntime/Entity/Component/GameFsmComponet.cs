using UnityEngine;

public class GameFsmComponent {

    public GameStatus status;

    public bool isEnterNormal;

    public void EnterNormal() {
        status = GameStatus.Normal;
        isEnterNormal = true;
    }
}