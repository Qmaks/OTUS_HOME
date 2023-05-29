using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class LevelBounds
    {
        [Inject] private LevelBoundSceneLinks links;
        
        public bool InBounds(Vector3 position)
        {
            var positionX = position.x;
            var positionY = position.y;
            return positionX > links.leftBorder.position.x
                   && positionX < links.rightBorder.position.x
                   && positionY > links.downBorder.position.y
                   && positionY < links.topBorder.position.y;
        }
    }
}