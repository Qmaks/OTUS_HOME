using System;
using Homework_4.SaveLoad.Scripts.Utils;
using UnityEngine;

namespace Homework_4.SaveLoad.Scripts.SaveLoadSystem
{
    public class SavableObject : GuidComponent
    {
	    #region internal
        [Serializable]
        public struct Data
        {
            public byte[] SceneID;
            public string Name;

            public TransformData Transform;
            public ComponentData[] Components;
        }

        [Serializable]
        public struct TransformData
        {
            public Vector3S Position;
            public QuaternionS Rotation;
			
            public TransformData(Transform transform)
            {
                Position = new Vector3S(transform.localPosition);
                Rotation = new QuaternionS(transform.localRotation);
            }
        }

        [Serializable]
        public struct ComponentData
        {
            public string GameObjectPath;
            public Type ComponentType;
            public object[] Members;


            public ComponentData(string gameObjectPath, Type componentType, object[] members)
            {
                Members = members;

                GameObjectPath = gameObjectPath;
                ComponentType = componentType;
            }
        }
        #endregion
        
        [SerializeField]
        private PrefabDatabase.ePrefabIDs PrefabID;
        
        public Data Save()
		{
			var data = new Data();

			data.SceneID = GetGuid().ToByteArray();
			data.Name = name;
			
			data.Transform = new TransformData(transform);

			// Save components
			var savComponents = GetComponentsInChildren<ISaveableComponent>();

			data.Components = new ComponentData[savComponents.Length];
			for(int i = 0;i < savComponents.Length;i++)
			{
				var gameObj = (savComponents[i] as Component).gameObject;
				var gameObjPath = CalculateTransformPath(transform, gameObj.transform);
				data.Components[i] = new ComponentData(gameObjPath, savComponents[i].GetType(), savComponents[i].SaveMembers());
			}

            return data;
		}

		public void Load(Data data)
		{
			gameObject.name = data.Name;
            SetGuid(data.SceneID);

			LoadTransform(transform, data.Transform);

			// Load components
			if (data.Components != null)
			{
				foreach (ComponentData compData in data.Components)
				{
					var obj = (compData.GameObjectPath != gameObject.name) ? transform.Find(compData.GameObjectPath) : transform;

					if (obj == null)
						continue;

					var component = obj.GetComponent(compData.ComponentType);

					if (component == null)
					{
						component = obj.gameObject.AddComponent(compData.ComponentType);
					}

					ISaveableComponent savComponent = component as ISaveableComponent;
					savComponent.LoadMembers(compData.Members);
                }
			}
		}

		private void LoadTransform(Transform transform, TransformData data)
		{
			transform.localPosition = data.Position.ToVector3();
			transform.localRotation = data.Rotation.ToQuaternion();
		}
        
        private string CalculateTransformPath(Transform root, Transform target)
        {
            string path = string.Empty;

            if (target != root)
            {
                path = target.name;
                Transform parent = target.parent;

                while (parent != null && parent != root)
                {
                    path = parent.name + (path != string.Empty ? "/" : "") + path;
                    parent = parent.parent;
                }
            }

            return path;
        }
    }
}