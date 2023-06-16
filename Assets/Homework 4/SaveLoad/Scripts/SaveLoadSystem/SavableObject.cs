﻿using System;
using Homework_4.SaveLoad.Scripts.Utils;
using Homeworks.SaveLoad.LevelResources;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Homework_4.SaveLoad.Scripts.SaveLoadSystem
{
    public class SavableObject : GuidComponent
    {
	    #region internal
        [Serializable]
        public struct Data
        {
            public string SceneID;
            public string PrefabID;
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
                Position = new Vector3S(transform.position);
                Rotation = new QuaternionS(transform.rotation);
            }
        }

        [Serializable]
        public struct ComponentData
        {
            public string GameObjectPath;
            public Type ComponentType;
            public string[] Members;


            public ComponentData(string gameObjectPath, Type componentType, string[] members)
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

			data.PrefabID = PrefabID.ToString();
			data.SceneID  = GetGuid().ToString();
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

					var savComponent = component as ISaveableComponent;
					savComponent.LoadMembers(compData.Members);
                }
			}
		}

		private void LoadTransform(Transform transform, TransformData data)
		{
			transform.position = data.Position.ToVector3();
			transform.rotation = data.Rotation.ToQuaternion();
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

        public class Factory : PlaceholderFactory<Transform,string,SavableObject>
        {
	        [Inject] private PrefabDatabase prefabDatabase;
	        [Inject] private DiContainer container;

	        public override SavableObject Create(Transform parent, string prefabId)
	        {
		        var prefab = prefabDatabase.GetPrefabWithID(prefabId);
		        var instance = container.InstantiatePrefabForComponent<SavableObject>(prefab);
				instance.transform.SetParent(parent);
				return instance;
	        }
        }
    }
}