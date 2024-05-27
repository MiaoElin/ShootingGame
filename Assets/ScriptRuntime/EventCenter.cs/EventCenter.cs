using UnityEngine;
using System;

public class EventCenter {

    public Action<int> Panel_Bag_OnclikGrid;
    public void UseStuff(int typeID) {
        Panel_Bag_OnclikGrid.Invoke(typeID);
    }
}