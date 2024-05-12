using UnityEngine;
using System;
using System.Collections.Generic;

public class Pool<T> {
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
            return stack.Pop();
        } else {
            return fuction();
        }
    }

    public void Return(T t) {
        stack.Push(t);
    }
}