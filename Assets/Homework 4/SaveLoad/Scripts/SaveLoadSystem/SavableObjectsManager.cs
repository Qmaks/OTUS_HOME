using System;
using System.Collections.Generic;
using System.Linq;
using Homework_4.SaveLoad.Scripts.SaveLoadSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Homeworks.SaveLoad.LevelResources
{
    public class SavableObjectsManager : MonoBehaviour
    {
        [Inject] private List<SavableObject> savableObjects;
        [Inject] private PrefabDatabase prefabDatabase;
        
        public void Setup(Dictionary<string,SavableObject.Data> data)
        {
            SetupSceneObjects(data);
            CreateObjectFromData(data);
        }

        private void CreateObjectFromData(Dictionary<string,SavableObject.Data> data)
        {
            foreach (var objData in data.Values)
            {
                 if (!savableObjects.Exists(obj => obj.GetGuid() == new Guid(objData.SceneID)))
                 {
                     var prefab = prefabDatabase.GetPrefabWithID(objData.PrefabID);
            
                     if (prefab != null)
                     {
                         var loadedObj = Instantiate<SavableObject>(prefab);
                         loadedObj.Load(objData);
                     }
                 }
            }
        }

        private void SetupSceneObjects(Dictionary<string, SavableObject.Data> data)
        {
            foreach (var so in savableObjects)
            {
                if (data.TryGetValue(so.GetGuid().ToString(), out SavableObject.Data objData))
                    so.Load(objData);
                else
                    Destroy(so.gameObject);
            }
        }

        public Dictionary<string,SavableObject.Data> GetObjects()
        {
            return savableObjects.Select(so => so.Save()).ToDictionary(data => data.SceneID.ToString());
        }
    }
}
