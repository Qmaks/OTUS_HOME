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
        [SerializeField] private Transform initialPosition;
        
        [Inject] private DiContainer container;
        [Inject] private SavableObject.Factory factory;
        [Inject] private List<SavableObject> savableObjects;


        [Button(ButtonSizes.Large),GUIColor(0,1,0)]
        public void Create(PrefabDatabase.ePrefabIDs prefabID )
        {
            var newSavableObject = factory.Create(transform, prefabID.ToString());
            newSavableObject.transform.position = initialPosition.position;
            newSavableObject.CreateGuid();
            
            if (newSavableObject != null)
                savableObjects.Add(newSavableObject);
        }

        [Button(ButtonSizes.Large),GUIColor(0,1,0)]
        public void Remove(SavableObject obj)
        {
            savableObjects.Remove(obj);
            Destroy(obj.gameObject);
        }

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
                     var newSavableObject = factory.Create(transform, objData.PrefabID);
                     
                     if (newSavableObject != null)
                     {
                         newSavableObject.Load(objData);
                         savableObjects.Add(newSavableObject);
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
