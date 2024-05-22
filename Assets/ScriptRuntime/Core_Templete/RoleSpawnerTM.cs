using UnityEngine;
using System;

[Serializable]
public class RoleSpawnerTM {

    public Vector3 pos;
    public Vector3 rot;
    public Vector3 scale;
    public int roleTypeID; //只要ID信息,不需要tm（如果放的Tm,那是不是生成会更快？Spawn的时候不用gettm了，可以直接用）；propTM里的要tm是用于生成mod，便于显示；
}