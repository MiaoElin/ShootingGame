using UnityEngine;
using UnityEngine.UI;

public class Panel_CrossHair : MonoBehaviour {
    // [SerializeField] Image crossHair;

    public void Ctor() {

    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}