using UnityEngine;
using System;
using System.Collections.Generic;

public class Pool<T> {
    Stack<T> stack;
    Func<T> fuction;
}