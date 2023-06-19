using Homework_4.SaveLoad.Scripts.Utils;
using UnityEngine;

namespace Homework_4.SaveLoad.Scripts.SaveLoadSystem
{
    public class TransformData
    {
        private Vector3S position;
        private QuaternionS rotation;
			
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