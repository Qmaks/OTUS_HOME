using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour, IFixedTickable
    {
        private float startPositionY;
        private float endPositionY;
        private float movingSpeedY;
        private float positionX;
        private float positionZ;

        private Transform myTransform;

        [SerializeField]
        private Params mParams;

        private void Awake()
        {
            startPositionY = mParams.startPositionY;
            endPositionY = mParams.endPositionY;
            movingSpeedY = mParams.movingSpeedY;
            myTransform = transform;
            var position = myTransform.position;
            positionX = position.x;
            positionZ = position.z;
        }

        public void FixedTick()
        {
            if (this.myTransform.position.y <= this.endPositionY)
            {
                myTransform.position = new Vector3(
                    positionX,
                    startPositionY,
                    positionZ
                );
            }

            this.myTransform.position -= new Vector3(
                positionX,
                movingSpeedY * Time.fixedDeltaTime,
                positionZ
            );
        }

        [Serializable]
        public sealed class Params
        {
            [SerializeField]
            public float startPositionY;

            [SerializeField]
            public float endPositionY;

            [SerializeField]
            public float movingSpeedY;
        }
    }
}