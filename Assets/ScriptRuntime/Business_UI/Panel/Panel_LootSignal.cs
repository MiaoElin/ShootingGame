using UnityEngine;
using UnityEngine.UI;

public class Panel_LootSignal : MonoBehaviour {
    [SerializeField] public Image image;
    [SerializeField] public Text lootName;

    public void Ctor(Sprite spr, string lootName) {
        image.sprite = spr;
        this.lootName.text = lootName;
    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

}