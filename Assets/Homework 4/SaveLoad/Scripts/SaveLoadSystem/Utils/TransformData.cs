using System;
using Homework_4.SaveLoad.Scripts.Utils;
using UnityEngine;

namespace Homework_4.SaveLoad.Scripts.SaveLoadSystem
{
    [Serializable]
    public class TransformData
    {
        public Vector3S position;
        public QuaternionS rotation;
			
        public TransformData(Transform transform)
        {
            position = new Vector3S(transform.position);
            rotation = new QuaternionS(transform.rotation);
        }

        public void Setup(Transform transform)
        {
            transform.position = position.ToVector3();
            transform.rotation = rotation.ToQuaternion();
        }
    }
}