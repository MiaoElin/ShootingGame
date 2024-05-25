using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_CrossHair : MonoBehaviour {
    [SerializeField] GameObject tps_CrossHair;
    [SerializeField] GameObject fps_CrossHair;

    public void Ctor() {

    }

    public void Show_TPS() {
        tps_CrossHair.SetActive(true);
    }

    public void Hide_TPS() {
        tps_CrossHair.SetActive(false);
    }

    internal void Hide_FPS() {
        fps_CrossHair.SetActive(false);
    }

    internal void Show_FPS() {
        fps_CrossHair.SetActive(true);
    }
}