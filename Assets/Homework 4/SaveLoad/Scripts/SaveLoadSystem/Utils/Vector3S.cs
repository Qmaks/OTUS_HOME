using System;
using UnityEngine;

[Serializable]
public struct Vector3S
{
    public float x;
    public float y;
    public float z;
 
    public Vector3S(Vector3 vector3)
    {
        this.x = vector3.x;
        this.y = vector3.y;
        this.z = vector3.z;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}