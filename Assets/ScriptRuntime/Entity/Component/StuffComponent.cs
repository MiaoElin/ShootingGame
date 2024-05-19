using UnityEngine;

public class StuffComponent {
    StuffModel[] stuffs;
    int capacity;

    public StuffComponent() {
    }

    public void Ctor(int capacity) {
        this.capacity = capacity;
        stuffs = new StuffModel[capacity];
    }

    // public bool IsAdd() {

    // }
}