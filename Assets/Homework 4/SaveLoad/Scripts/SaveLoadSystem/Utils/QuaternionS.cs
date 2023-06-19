using System;
using UnityEngine;

namespace Homework_4.SaveLoad.Scripts.Utils
{
    [Serializable]
    public class QuaternionS
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public QuaternionS(Quaternion quaternion)
        {
            x = quaternion.x;
            y = quaternion.y;
            z = quaternion.z;
            w = quaternion.w;
        }

        public Quaternion ToQuaternion()
        {
            return new Quaternion(x, y, z, w);
        }
    }
}