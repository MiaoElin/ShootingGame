using UnityEngine;
using System;
using System.Collections.Generic;

public class Pool<T> where T : MonoBehaviour {
    Stack<T> stack;
    Func<T> fuction;
    Action action;

    public Pool(Func<T> function, int count) {
        stack = new Stack<T>(count);
        this.fuction = function;
        for (int i = 0; i < count; i++) {
            stack.Push(fuction());
        }
        // action += () => {
        //     Get();
        // };
        // fuction = () => Get();
    }

    public T Get() {
        if (stack.Count > 0) {
            var t = stack.Pop();
            t.gameObject.SetActive(true);
            return t;

        } else {
            return fuction();
        }
    }

    public void Return(T t) {
        t.gameObject.SetActive(false);
        stack.Push(t);
    }
}