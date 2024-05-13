using UnityEngine;
using System.Collections.Generic;

public class UIRepo {

    Dictionary<string, GameObject> allUIs;

    public UIRepo() {
        allUIs = new Dictionary<string, GameObject>();
    }

    public void Add(string name, GameObject ui) {
        allUIs.Add(name, ui);
    }

    public T Tryget<T>() where T : MonoBehaviour {
        var has = allUIs.TryGetValue(typeof(T).Name, out GameObject ui);
        if (has) {
            return ui.GetComponent<T>();
        } else {
            return null;
        }
    }
}